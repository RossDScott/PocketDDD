using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using MudBlazor;
using PocketDDD.Shared.API.ResponseDTOs;
using PocketDDD.Shared.API.RequestDTOs;

namespace PocketDDD.BlazorClient.Services;

public interface IPocketDDDApiService
{
    Task<LoginResultDTO> Login(string name);
    void SetUserAuthToken(string token);

    Task<EventDataResponseDTO?> FetchLatestEventData(EventDataUpdateRequestDTO requestDTO);
    Task<FeedbackResponseDTO> SubmitClientEventFeedback(SubmitEventFeedbackDTO feedbackDTO);
    Task<FeedbackResponseDTO> SubmitClientSessionFeedback(SubmitSessionFeedbackDTO feedbackDTO);
}

public class PocketDDDApiService : IPocketDDDApiService
{
    private readonly HttpClient _http;

    public PocketDDDApiService(HttpClient http)
    {
        _http = http;
    }

    public void SetUserAuthToken(string token)
    {
        _http.DefaultRequestHeaders.Clear();
        _http.DefaultRequestHeaders.Add("Authorization", token);
    }

    public async Task<EventDataResponseDTO?> FetchLatestEventData(EventDataUpdateRequestDTO requestDTO)
    {
        var response = await _http.PostAsJsonAsync<EventDataUpdateRequestDTO>("EventData/FetchLatestEventData", requestDTO);

        if (response.StatusCode == HttpStatusCode.NoContent)
            return null;

        return (await response.Content.ReadFromJsonAsync<EventDataResponseDTO>())!;
    }
    
    public async Task<LoginResultDTO> Login(string name)
    {
        var dto = new RegisterDTO { Name = name };
        var response = await _http.PostAsJsonAsync("Registration/Login", dto);
        return (await response.Content.ReadFromJsonAsync<LoginResultDTO>())!;
    }

    public async Task<FeedbackResponseDTO> SubmitClientEventFeedback(SubmitEventFeedbackDTO feedbackDTO)
    {
        var response = await _http.PostAsJsonAsync("Feedback/ClientEventFeedback", feedbackDTO);
        return (await response.Content.ReadFromJsonAsync<FeedbackResponseDTO>())!;
    }

    public async Task<FeedbackResponseDTO> SubmitClientSessionFeedback(SubmitSessionFeedbackDTO feedbackDTO)
    {
        var response = await _http.PostAsJsonAsync("Feedback/ClientSessionFeedback", feedbackDTO);
        return (await response.Content.ReadFromJsonAsync<FeedbackResponseDTO>())!;
    }
}

public class FakePocketDDDApiService : IPocketDDDApiService
{
    public Task<LoginResultDTO> Login(string name)
    {
        return Task.FromResult(new LoginResultDTO(name, Guid.NewGuid().ToString()));
    }

    public void SetUserAuthToken(string token)
    {
        
    }

    public async Task<EventDataResponseDTO?> FetchLatestEventData(EventDataUpdateRequestDTO requestDTO)
    {
        if (requestDTO.Version == 1)
        {
            await Task.Delay(1000);
            return null;
        }

        return
            new EventDataResponseDTO
            {
                Version = 1,
                TimeSlots = new[]
                {
                    new TimeSlotDTO
                    {
                        Id = 1,
                        From = new DateTimeOffset(2023, 4, 29, 8, 00, 0, TimeSpan.Zero),
                        To = new DateTimeOffset(2023, 4, 29, 8, 30, 0, TimeSpan.Zero),
                        Info = "Registration"
                    },
                    new TimeSlotDTO
                    {
                        Id = 2,
                        From = new DateTimeOffset(2023, 4, 29, 8, 30, 0, TimeSpan.Zero),
                        To = new DateTimeOffset(2023, 4, 29, 9, 0, 0, TimeSpan.Zero),
                        Info = "Intro"
                    },
                    new TimeSlotDTO
                    {
                        Id = 3,
                        From = new DateTimeOffset(2023, 4, 29, 9, 00, 0, TimeSpan.Zero),
                        To = new DateTimeOffset(2023, 4, 29, 10, 00, 0, TimeSpan.Zero)
                    },
                    new TimeSlotDTO
                    {
                        Id = 4,
                        From = new DateTimeOffset(2023, 4, 29, 10, 0, 0, TimeSpan.Zero),
                        To = new DateTimeOffset(2023, 4, 29, 10, 20, 0, TimeSpan.Zero),
                        Info = "Coffee"
                    },
                    new TimeSlotDTO
                    {
                        Id = 5,
                        From = new DateTimeOffset(2023, 4, 29, 10, 20, 0, TimeSpan.Zero),
                        To = new DateTimeOffset(2023, 4, 29, 11, 20, 0, TimeSpan.Zero)
                    },
                },
                Tracks = new[]
                {
                    new TrackDTO { Id = 1, Name = "Track 1", RoomName = "Room 1" },
                    new TrackDTO { Id = 2, Name = "Track 2", RoomName = "Room 2" },
                    new TrackDTO { Id = 3, Name = "Track 3", RoomName = "Room 3" }
                },
                Sessions = new[]
                {
                    new SessionDTO
                    {
                        Id = 1,
                        FullDescription = "Some full desk",
                        Speaker = "Ross",
                        TimeSlotId = 3,
                        TrackId = 1,
                        Title = "Blazor Session Management"
                    },
                    new SessionDTO
                    {
                        Id = 2,
                        FullDescription = "Second session",
                        Speaker = "Jim",
                        TimeSlotId = 3,
                        TrackId = 2,
                        Title = "How to code"
                    },
                    new SessionDTO
                    {
                        Id = 3,
                        FullDescription = "Third session",
                        Speaker = "Bob",
                        TimeSlotId = 5,
                        TrackId = 2,
                        Title = "Off by 1"
                    },
                }
            };
    }

    public Task<FeedbackResponseDTO> SubmitClientEventFeedback(SubmitEventFeedbackDTO feedbackDTO)
    {
        return Task.FromResult(new FeedbackResponseDTO { ClientId = feedbackDTO.ClientId, Score = 2 });
    }

    public Task<FeedbackResponseDTO> SubmitClientSessionFeedback(SubmitSessionFeedbackDTO feedbackDTO)
    {
        return Task.FromResult(new FeedbackResponseDTO { ClientId = feedbackDTO.ClientId, Score = 3 });
    }
}