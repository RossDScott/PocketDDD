using PocketDDD.Shared.API.ResponseDTOs;
using PocketDDD.Shared.API.RequestDTOs;

namespace PocketDDD.BlazorClient.Services;

public interface IPocketDDDApiService
{
    Task<LoginResult> Login(string name);

    Task<EventDataResponse?> FetchLatestEventData(EventDataUpdateRequest request);
}

public class PocketDDDApiService : IPocketDDDApiService
{
    private readonly HttpClient _http;

    public PocketDDDApiService(HttpClient http)
    {
        _http = http;
    }

    public Task<EventDataResponse?> FetchLatestEventData(EventDataUpdateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResult> Login(string name)
    {
        throw new NotImplementedException();
    }
}

public class FakePocketDDDApiService : IPocketDDDApiService
{
    public Task<LoginResult> Login(string name)
    {
        return Task.FromResult(new LoginResult(name, Guid.NewGuid().ToString()));
    }

    public Task<EventDataResponse?> FetchLatestEventData(EventDataUpdateRequest request)
    {
        return Task.FromResult<EventDataResponse?>(
            new EventDataResponse
            {
                Version = 1,
                TimeSlots = new[]
                {
                    new TimeSlot{
                        Id = 1,
                        From = new DateTimeOffset(2023,4,29,8,00,0,TimeSpan.Zero),
                        To= new DateTimeOffset(2023,4,29,8,30,0,TimeSpan.Zero),
                        Info = "Registration"
                    },
                    new TimeSlot{
                        Id = 2,
                        From = new DateTimeOffset(2023,4,29,8,30,0,TimeSpan.Zero),
                        To= new DateTimeOffset(2023,4,29,9,0,0,TimeSpan.Zero),
                        Info = "Intro"
                    },
                    new TimeSlot{
                        Id = 3,
                        From = new DateTimeOffset(2023,4,29,9,00,0,TimeSpan.Zero),
                        To = new DateTimeOffset(2023,4,29,10,00,0,TimeSpan.Zero)
                    },
                    new TimeSlot{
                        Id = 4,
                        From = new DateTimeOffset(2023,4,29,10,0,0,TimeSpan.Zero),
                        To = new DateTimeOffset(2023,4,29,10,20,0,TimeSpan.Zero),
                        Info = "Coffee"
                    },
                    new TimeSlot{
                        Id = 5,
                        From = new DateTimeOffset(2023,4,29,10,20,0,TimeSpan.Zero),
                        To = new DateTimeOffset(2023,4,29,11,20,0,TimeSpan.Zero)
                    },
                },
                Tracks = new[]
                {
                    new Track { Id = 1, Name = "Track 1", RoomName = "Room 1"},
                    new Track { Id = 2, Name = "Track 2", RoomName = "Room 2"},
                    new Track { Id = 3, Name = "Track 3", RoomName = "Room 3"}
                },
                Sessions = new[]
                {
                    new Session { 
                        Id = 1, 
                        FullDescription = "Some full desk", 
                        Speaker = "Ross", 
                        TimeSlotId = 3,
                        TrackId = 1,
                        Title = "Blazor Session Management"
                    },
                    new Session {
                        Id = 2,
                        FullDescription = "Second session",
                        Speaker = "Jim",
                        TimeSlotId = 3,
                        TrackId = 2,
                        Title = "How to code"
                    },
                    new Session {
                        Id = 3,
                        FullDescription = "Third session",
                        Speaker = "Bob",
                        TimeSlotId = 5,
                        TrackId = 2,
                        Title = "Off by 1"
                    },
                }
            }
        );
    }
}