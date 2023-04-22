using Microsoft.EntityFrameworkCore;
using PocketDDD.Server.DB;
using PocketDDD.Server.Model.DBModel;
using PocketDDD.Server.Model.DTOs;
using PocketDDD.Shared.API.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.Server.Services;
public class FeedbackService
{
    private readonly PocketDDDContext dbContext;
    private readonly UserService userService;

    public FeedbackService(PocketDDDContext dbContext, UserService userService)
    {
        this.dbContext = dbContext;
        this.userService = userService;
    }

    public async Task<FeedbackResponseDTO> SubmitClientSessionFeedback(SubmitSessionFeedbackDTO clientData, int userId)
    {
        var user = await dbContext.Users.SingleAsync(x => x.Id == userId);
        var feedback = await dbContext.UserSessionFeedback
                                      .Where(x => x.EventDetailId == user.EventDetailId && 
                                                  x.SessionId == clientData.SessionId && 
                                                  x.UserId == user.Id)
                                      .FirstOrDefaultAsync();
        if (feedback == null)
        {
            feedback = new UserSessionFeedback
            {
                EventDetailId = user.EventDetailId,
                SessionId = clientData.SessionId,
                UserId = user.Id,
            };

            dbContext.UserSessionFeedback.Add(feedback);
        }

        if (clientData.CreatedOn > feedback.DateTimestamp)
        {
            feedback.SpeakerKnowledgeRating = clientData.SpeakerKnowledgeRating;
            feedback.SpeakerSkillsRating = clientData.SpeakingSkillRating;
            feedback.Comment = clientData.Comments;
            feedback.DateTimestamp = clientData.CreatedOn;

            await dbContext.SaveChangesAsync();

            await userService.CalculateAndUpdateEventScore(user);
        }

        return new FeedbackResponseDTO { ClientId = clientData.ClientId, Score = user.EventScore };
    }

    public async Task<FeedbackResponseDTO> SubmitClientEventFeedback(SubmitEventFeedbackDTO clientData, int userId)
    {
        var user = await dbContext.Users.SingleAsync(x => x.Id == userId);
        var feedback = await dbContext.UserEventFeedback
                                      .Where(x => x.EventDetailId == user.EventDetailId && 
                                                  x.UserId == user.Id)
                                      .FirstOrDefaultAsync();
        if (feedback == null)
        {
            feedback = new UserEventFeedback
            {
                EventDetailId = user.EventDetailId,
                UserId = user.Id
            };
            dbContext.UserEventFeedback.Add(feedback);
        }

        if (clientData.CreatedOn > feedback.DateTimestamp)
        {
            feedback.Venue = clientData.VenueRating;
            feedback.Refreshments = clientData.RefreshmentsRating;
            feedback.Overall = clientData.OverallRating;
            feedback.Comment = clientData.Comments;
            feedback.DateTimestamp = clientData.CreatedOn;

            await dbContext.SaveChangesAsync();

            await userService.CalculateAndUpdateEventScore(user);
        }

        return new FeedbackResponseDTO { ClientId = clientData.ClientId, Score = user.EventScore };
    }
}