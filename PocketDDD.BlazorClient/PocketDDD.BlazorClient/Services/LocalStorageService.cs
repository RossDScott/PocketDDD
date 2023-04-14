using Blazored.LocalStorage;
using Fluxor;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Services;

public class LocalStorageService
{
    private const string Key_CurrentUser = "currentUser";
    private const string Key_SessionBookmarks = "sessionBookmarks";
    private const string Key_EventData = "eventData";

    private readonly ILocalStorageService _localStorage;
    private readonly IDispatcher _dispatcher;

    public LocalStorageService(ILocalStorageService localStorage, IDispatcher dispatcher)
    {
        _localStorage = localStorage;
        _dispatcher = dispatcher;

        SubscribeAndDispatch();
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

    public ValueTask<LoginResult?> GetCurrentUser() => _localStorage.GetItemAsync<LoginResult?>(Key_CurrentUser); 
    public ValueTask SetCurrentUser(LoginResult loginResult) => _localStorage.SetItemAsync(Key_CurrentUser, loginResult);

    public ValueTask<EventDataResponse?> GetEventData() => _localStorage.GetItemAsync<EventDataResponse?>(Key_EventData);
    public ValueTask SetEventData(EventDataResponse eventData) => _localStorage.SetItemAsync(Key_EventData, eventData);

    public async ValueTask<IList<int>> GetSessionBookmarks() => 
        await (_localStorage.GetItemAsync<IList<int>?>(Key_SessionBookmarks)) 
        ?? new List<int>();
    public ValueTask SetSessionBookmarks(IList<int> sessionBookmarks) => _localStorage.SetItemAsync(Key_SessionBookmarks, sessionBookmarks);

}
