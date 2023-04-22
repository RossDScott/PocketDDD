using Microsoft.EntityFrameworkCore;
using PocketDDD.Server.DB;
using PocketDDD.Server.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Services;
public class UserService
{
    private readonly PocketDDDContext dbContext;

    public UserService(PocketDDDContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<User?> FetchUserByToken(string token)
    {
        return dbContext.Users.SingleOrDefaultAsync(x => x.Token == token);
    }

    public async Task CalculateAndUpdateEventScore(User user)
    {
        var sessionFeedbackCount = await dbContext.UserSessionFeedback
                                                  .Where(x => x.EventDetailId == user.EventDetailId && 
                                                              x.UserId == user.Id)
                                                  .Select(x => x.Session.TimeSlot.Id)
                                                  .Distinct()
                                                  .CountAsync();

        var eventFeedbackCount = await dbContext.UserEventFeedback
                                                .Where(x => x.EventDetailId == user.EventDetailId &&
                                                            x.UserId == user.Id)
                                                .CountAsync();

        if (eventFeedbackCount > 0)
            eventFeedbackCount = 3;

        var total = sessionFeedbackCount + eventFeedbackCount + 1;
        if (total > user.EventScore)
        {
            user.EventScore = total;
            await dbContext.SaveChangesAsync();
        }
    }
}
