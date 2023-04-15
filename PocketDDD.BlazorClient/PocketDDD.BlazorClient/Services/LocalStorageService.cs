using Blazored.LocalStorage;
using Fluxor;
using PocketDDD.BlazorClient.Features.EventFeedback.Models;
using PocketDDD.BlazorClient.Features.EventFeedback.Store;
using PocketDDD.Shared.API.RequestDTOs;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Services;

public class LocalStorageService
{
    public const string Key_CurrentUser = "currentUser";
    public const string Key_SessionBookmarks = "sessionBookmarks";
    public const string Key_EventData = "eventData";
    public const string Key_EventFeedback = "eventFeedback";
    public const string Key_EventFeedbackPrefix = "eventFeedback_";

    private readonly ILocalStorageService _localStorage;
    private readonly IDispatcher _dispatcher;

    public LocalStorageService(ILocalStorageService localStorage, IDispatcher dispatcher)
    {
        _localStorage = localStorage;
        _dispatcher = dispatcher;

        SubscribeAndDispatch();
    }

    private void SubscribeToKey(string key, Action action)
    {
        _localStorage.Changed += (sender, args) =>
        {
            if (args.Key == key)
                action();
        };
    }

    public void SubscribeToSyncItem(string keyPrefix, Action action)
    {
        _localStorage.Changed += (sender, args) =>
        {
            if (args.Key.StartsWith(keyPrefix))
                action();
        };
    }

    private void SubscribeAndDispatch()
    {
        _localStorage.Changed += (sender, args) =>
        {
            switch (args.Key)
            {
                case Key_EventData:
                    _dispatcher.Dispatch(new EventDataUpdatedAction());
                    break;
                case Key_SessionBookmarks:
                    _dispatcher.Dispatch(new BookmarksUpdatedAction());
                    break;
            }
        };
    }

    public ValueTask<LoginResultDTO?> GetCurrentUser() => _localStorage.GetItemAsync<LoginResultDTO?>(Key_CurrentUser); 
    public ValueTask SetCurrentUser(LoginResultDTO loginResult) => _localStorage.SetItemAsync(Key_CurrentUser, loginResult);

    public ValueTask<EventDataResponseDTO?> GetEventData() => _localStorage.GetItemAsync<EventDataResponseDTO?>(Key_EventData);
    public ValueTask SetEventData(EventDataResponseDTO eventData) => _localStorage.SetItemAsync(Key_EventData, eventData);

    public async ValueTask<IList<int>> GetSessionBookmarks() => 
        await (_localStorage.GetItemAsync<IList<int>?>(Key_SessionBookmarks)) 
        ?? new List<int>();
    public ValueTask SetSessionBookmarks(IList<int> sessionBookmarks) => _localStorage.SetItemAsync(Key_SessionBookmarks, sessionBookmarks);

    public ValueTask<EventFeedback?> GetEventFeedback() => _localStorage.GetItemAsync<EventFeedback?>(Key_EventFeedback);
    public ValueTask SetEventFeedback(EventFeedback feedback) => _localStorage.SetItemAsync(Key_EventFeedback, feedback);

    public ValueTask AddEventFeedbackSyncItem(SubmitEventFeedbackDTO dto) =>
        _localStorage.SetItemAsync(Key_EventFeedbackPrefix + dto.ClientId, dto);
}
