using Blazored.LocalStorage;
using Fluxor;
using PocketDDD.BlazorClient.Features.EventFeedback.Models;
using PocketDDD.BlazorClient.Features.EventFeedback.Store;
using PocketDDD.Shared.API.RequestDTOs;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Services;

public class LocalStorageService
{
    private readonly ILocalStorageService _localStorage;
    private readonly IDispatcher _dispatcher;

    public KeyItem<LoginResultDTO> CurrentUser { get; }
    public KeyItem<IList<int>> SessionBookmarks { get; }
    public KeyItem<EventDataResponseDTO> EventData { get; }
    public KeyItem<EventFeedback> EventFeedback { get; }
    public KeySyncItem<SubmitEventFeedbackDTO> EventFeedbackSync {get;}
    public LocalStorageService(ILocalStorageService localStorage, IDispatcher dispatcher)
    {
        _localStorage = localStorage;
        _dispatcher = dispatcher;

        CurrentUser = createKeyItem<LoginResultDTO>("CurrentUser");
        EventData = createKeyItem<EventDataResponseDTO>("EventData");
        SessionBookmarks = createKeyItem<IList<int>>("SessionBookmarks");
        EventFeedback = createKeyItem<EventFeedback>();
        EventFeedbackSync = createKeySyncItem<SubmitEventFeedbackDTO>();
    }

    private KeyItem<T> createKeyItem<T>() =>
        createKeyItem<T>(typeof(T).Name);

    private KeyItem<T> createKeyItem<T>(string key) =>
        new KeyItem<T>(_localStorage, key);

    private KeySyncItem<T> createKeySyncItem<T>() =>
        createKeySyncItem<T>(typeof(T).Name);

    private KeySyncItem<T> createKeySyncItem<T>(string key) =>
        new KeySyncItem<T>(_localStorage, key);
}

public class KeyItem<T>
{
    private readonly ILocalStorageService _localStorage;
    private readonly string _key;

    public KeyItem(ILocalStorageService localStorage, string key)
    {
        _localStorage = localStorage;
        _key = key;
    }

    public ValueTask<T?> GetAsync() => _localStorage.GetItemAsync<T?>(_key);
    public async ValueTask<T> GetOrDefaultAsync(Func<T> defaultConstructor)
    {
        var val = await _localStorage.GetItemAsync<T?>(_key);
        return val ?? defaultConstructor();
    }
        
    public ValueTask SetAsync(T item) => _localStorage.SetItemAsync(_key, item);

    public void SubscribeToChanges(Action<T> callback)
    {
        _localStorage.Changed += (sender, args) =>
        {
            if (args.Key == _key)
                callback((T) args.NewValue);
        };
    }
}

public class KeySyncItem<T>
{
    private readonly ILocalStorageService _localStorage;
    private readonly string _keyPrefix;

    public KeySyncItem(ILocalStorageService localStorage, string key)
    {
        _localStorage = localStorage;
        _keyPrefix = $"{key}_sync_";
    }
    private ValueTask<T> GetItemAsync(string key) => _localStorage.GetItemAsync<T>(key);
    public ValueTask<T?> GetSyncItemAsync(string clientId) => _localStorage.GetItemAsync<T?>(_keyPrefix + clientId);
    public async ValueTask<IList<T>> GetAllSyncItemsAsync()
    {
        var items = new List<T>();
        var keys = await _localStorage.KeysAsync();
        foreach (var key in keys)
        {
            if (key.StartsWith(_keyPrefix))
                items.Add((await GetItemAsync(key)));
        }
        return items;
    }

    public ValueTask AddSyncItemAsync(T item, string clientId) => 
        _localStorage.SetItemAsync(_keyPrefix + clientId, item);

    public void SubscribeToChanges(Action<IList<T>> callback)
    {
        _localStorage.Changed += async (sender, args) =>
        {
            if (args.Key.StartsWith(_keyPrefix))
                callback((await GetAllSyncItemsAsync()));
        };
    }
}