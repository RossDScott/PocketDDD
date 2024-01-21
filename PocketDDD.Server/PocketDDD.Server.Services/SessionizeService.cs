using Microsoft.EntityFrameworkCore;
using PocketDDD.Server.DB;
using PocketDDD.Server.Model.DBModel;
using PocketDDD.Server.Model.Sessionize;
using System.Net.Http.Json;

namespace PocketDDD.Server.Services;
public class SessionizeService
{
    private readonly HttpClient httpClient;
    private readonly PocketDDDContext dbContext;

    public SessionizeService(HttpClient httpClient, PocketDDDContext dbContext)
    {
        this.httpClient = httpClient;
        this.dbContext = dbContext;
        httpClient.BaseAddress = new Uri("https://sessionize.com/api/v2/");
    }

    public async Task UpdateFromSessionize()
    {
        var dbEvent = await dbContext.EventDetail.SingleAsync(x => x.Id == 1);

        var sessionizeEventId = dbEvent.SessionizeId;
        var sessionizeEvent = await httpClient.GetFromJsonAsync<SessionizeEvent>($"{sessionizeEventId}/view/All");

        if (sessionizeEvent is null)
            throw new ArgumentNullException(nameof(sessionizeEvent));

        var dbTracks = await dbContext.Tracks.ToListAsync();
        foreach (var item in sessionizeEvent.rooms)
        {
            var dbTrack = dbTracks.SingleOrDefault(x => x.SessionizeId == item.id);
            if (dbTrack == null)
            {
                dbTrack = new Track
                {
                    SessionizeId = item.id,
                    EventDetail = dbEvent
                };
                dbContext.Tracks.Add(dbTrack);
            }

            dbTrack.RoomName = item.name;
            dbTrack.Name = $"Track {item.sort}";
        }

        await dbContext.SaveChangesAsync();


        var dbTimeSlots = await dbContext.TimeSlots.ToListAsync();
        var sessionizeTimeSlots = sessionizeEvent.sessions
            .Select(x => (x.startsAt, x.endsAt))
            .Distinct()
            .ToList();

        foreach (var item in sessionizeTimeSlots)
        {
            var dbTimeSlot = dbTimeSlots.SingleOrDefault(x => x.From == item.startsAt && x.To == item.endsAt);
            if (dbTimeSlot == null)
            {
                dbTimeSlot = new TimeSlot
                {
                    EventDetail = dbEvent,
                    From = item.startsAt,
                    To = item.endsAt,
                    Info = null
                };
                dbContext.TimeSlots.Add(dbTimeSlot);
            }
        }

        await dbContext.SaveChangesAsync();


        var dbSessions = await dbContext.Sessions.ToListAsync();
        var speakers = sessionizeEvent.speakers;
        dbTracks = await dbContext.Tracks.ToListAsync();
        dbTimeSlots = await dbContext.TimeSlots.ToListAsync();

        foreach (var item in sessionizeEvent.sessions)
        {
            var dbSession = dbSessions.SingleOrDefault(x => x.SessionizeId == item.id);
            if (dbSession == null)
            {
                dbSession = new Model.DBModel.Session
                {
                    SessionizeId = item.id,
                    EventDetail = dbEvent,
                    SpeakerToken = Guid.NewGuid(),
                    FullDescription = ""
                };
                dbContext.Sessions.Add(dbSession);
            }

            dbSession.Title = item.title;
            dbSession.ShortDescription = item.description;
            dbSession.Speaker = GetSpeakers(speakers, item.speakers);
            dbSession.Track = dbTracks.Single(x => x.SessionizeId == item.roomId);
            dbSession.TimeSlot = GetTimeSlot(dbTimeSlots, item.startsAt, item.endsAt);
        }

        await dbContext.SaveChangesAsync();
    }

    private string GetSpeakers(List<PocketDDD.Server.Model.Sessionize.Speaker> speakers, List<string> speakerIds)
        => speakerIds.Aggregate("", (acc, x) => acc + ", " + speakers.Single(s => s.id == x).fullName).Trim(',');

    private TimeSlot GetTimeSlot(List<TimeSlot> timeSlots, DateTime startsAt, DateTime endsAt)
        => timeSlots.Single(x => x.From == startsAt && x.To == endsAt);

}
