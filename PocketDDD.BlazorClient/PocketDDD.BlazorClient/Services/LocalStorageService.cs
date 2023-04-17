using Blazored.LocalStorage;
using PocketDDD.BlazorClient.Features.EventFeedback.Models;
using PocketDDD.BlazorClient.Features.SessionFeedback.Models;
using PocketDDD.Shared.API.RequestDTOs;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Services;

public class LocalStorageService : LocalStorageContext
{
    public KeyItem<LoginResultDTO> CurrentUser { get; init; }
    public KeyItem<ICollection<int>> SessionBookmarks { get; init; }
    public KeyItem<EventDataResponseDTO> EventData { get; init; }
    public KeyItem<EventFeedback> EventFeedback { get; init; }
    public KeyItem<ICollection<SessionFeedback>> SessionFeedbacks { get; init; }

    public KeySyncItem<SubmitEventFeedbackDTO> EventFeedbackSync { get; init; }

    public LocalStorageService(ILocalStorageService localStorage) : base(localStorage) { }
}

