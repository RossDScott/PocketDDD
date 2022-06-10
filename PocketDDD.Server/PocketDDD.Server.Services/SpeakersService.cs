using Microsoft.EntityFrameworkCore;
using PocketDDD.Server.DB;
using PocketDDD.Server.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Services;
public class SpeakersService
{
    private readonly PocketDDDContext dbContext;

    public SpeakersService(PocketDDDContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<SpeakerFeedbackResponseDTO?> FetchFeedback(Guid speakerToken)
    {
        var session = dbContext.Sessions.SingleOrDefault(x => x.SpeakerToken == speakerToken);
        if (session == null)
            return null;

        var allFeedback = await dbContext.UserSessionFeedback
                                            .Where(x => x.SessionId == session.Id)
                                            .ToListAsync();

        var feedbackResponse = new SpeakerFeedbackResponseDTO
        {
            SessionTitle = session.Title,
            SpeakerName = session.Speaker,
            Feedback = allFeedback.Select(f => new SpeakerFeedbackItem
            {
                Comment = f.Comment,
                SpeakerKnowledgeRating = f.SpeakerKnowledgeRating,
                SpeakerSkillsRating = f.SpeakerSkillsRating
            }).ToList(),
            AverageKnowledgeRating = 0,
            AverageSkillRating = 0
        };

        var feedbackCount = (decimal)feedbackResponse.Feedback.Count();
        if (feedbackCount == 0)
            return feedbackResponse;

        feedbackResponse.AverageKnowledgeRating = feedbackResponse.Feedback
                                                                  .Where(x => x.SpeakerKnowledgeRating != null)
                                                                  .Sum(x => (decimal)x.SpeakerKnowledgeRating!.Value) / feedbackCount;

        feedbackResponse.AverageSkillRating = feedbackResponse.Feedback
                                                              .Where(x => x.SpeakerSkillsRating != null)
                                                              .Sum(x => (decimal)x.SpeakerSkillsRating!.Value) / feedbackCount;

        return feedbackResponse;
    }
}
