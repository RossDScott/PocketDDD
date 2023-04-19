using Blazored.LocalStorage;
using PocketDDD.BlazorClient.Features.EventFeedback.Models;
using PocketDDD.BlazorClient.Features.SessionFeedback.Models;
using PocketDDD.Shared.API.RequestDTOs;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Services;

public class LocalStorageService : LocalStorageContext
{
    public KeyItem<LoginResultDTO> CurrentUser { get; init; }
    public KeyListItem<int> SessionBookmarks { get; init; }
    public KeyItem<EventDataResponseDTO> EventData { get; init; }
    public KeyItem<EventFeedback> EventFeedback { get; init; }
    public KeyListItem<SessionFeedback> SessionFeedbacks { get; init; }

    public KeySyncItem<SubmitEventFeedbackDTO> EventFeedbackSync { get; init; }
    public KeySyncItem<SubmitSessionFeedbackDTO> SessionFeedbackSync { get; init; }

    public LocalStorageService(ILocalStorageService localStorage) : base(localStorage) { }
}

