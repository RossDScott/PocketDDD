using Blazored.LocalStorage;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Services;

public class LocalStorageService
{
    private const string Key_CurrentUser = "currentUser";
    private const string Key_SessionBookmarks = "sessionBookmarks";

    private readonly ILocalStorageService _localStorage;

    public LocalStorageService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public ValueTask<LoginResult?> GetCurrentUser() => _localStorage.GetItemAsync<LoginResult?>(Key_CurrentUser); 
    public ValueTask SetCurrentUser(LoginResult loginResult) => _localStorage.SetItemAsync(Key_CurrentUser, loginResult);

    public ValueTask<EventDataResponse?> GetEventData() => _localStorage.GetItemAsync<EventDataResponse?>("eventData");
    public ValueTask SetEventData(EventDataResponse eventData) => _localStorage.SetItemAsync("eventData", eventData);

    public async ValueTask<IList<int>> GetSessionBookmarks() => 
        await (_localStorage.GetItemAsync<IList<int>?>(Key_SessionBookmarks)) 
        ?? new List<int>();
    public ValueTask SetSessionBookmarks(IList<int> sessionBookmarks) => _localStorage.SetItemAsync(Key_SessionBookmarks, sessionBookmarks);

}
