using Blazored.LocalStorage;
using Fluxor;
using PocketDDD.BlazorClient.Features.EventFeedback.Models;
using PocketDDD.BlazorClient.Features.EventFeedback.Store;
using PocketDDD.Shared.API.RequestDTOs;
using PocketDDD.Shared.API.ResponseDTOs;
using System.Reflection;

namespace PocketDDD.BlazorClient.Services;

public class LocalStorageService : LocalStorageContext
{
    public KeyItem<LoginResultDTO> CurrentUser { get; init; }
    public KeyItem<IList<int>> SessionBookmarks { get; init; }
    public KeyItem<EventDataResponseDTO> EventData { get; init; }
    public KeyItem<EventFeedback> EventFeedback { get; init; }
    public KeySyncItem<SubmitEventFeedbackDTO> EventFeedbackSync { get; init; }

    public LocalStorageService(ILocalStorageService localStorage) : base(localStorage) { }
}

