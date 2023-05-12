using System.Reflection;
using Blazored.LocalStorage;

namespace PocketDDD.BlazorClient.LocalStorage;

public abstract class LocalStorageContext
{
    private readonly ILocalStorageService _localStorage;

    protected LocalStorageContext(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;

        InitialiseKeys(typeof(KeyItem<>));
        InitialiseKeys(typeof(KeyListItem<>));
        InitialiseKeys(typeof(KeySyncItem<>));
    }

    public ValueTask DeleteAllDataAsync() => _localStorage.ClearAsync();

    private void InitialiseKeys(Type keyType)
    {
        this.GetType()
            .GetProperties()
            .Where(p => p.PropertyType.IsGenericType &&
                        p.PropertyType.GetGenericTypeDefinition() == keyType)
            .ToList()
            .ForEach(item =>
            {
                Type itemType = item.PropertyType.GetGenericArguments()[0];
                Type genericType = keyType.MakeGenericType(itemType);

                ConstructorInfo? constructor = genericType.GetConstructor(new[] { typeof(ILocalStorageService), typeof(string) });
                object? instance = constructor?.Invoke(new object[] { _localStorage, item.Name });
                item.SetValue(this, instance);
            });
    }
}

public class KeyItem<T>
{
    protected readonly ILocalStorageService _localStorage;
    protected readonly string _key;

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
        _localStorage.Changed += (_, args) =>
        {
            if (args.Key == _key)
                callback((T)args.NewValue);
        };
    }
}

public class KeyListItem<T> : KeyItem<List<T>>
{
    public KeyListItem(ILocalStorageService localStorage, string key) : base(localStorage, key) { } 
    
    public async ValueTask<List<T>> GetOrDefaultAsync() => await GetAsync() ?? new List<T>();
}

public class KeySyncItem<T> : KeyItem<T>
{
    public KeySyncItem(ILocalStorageService localStorage, string key) : base(localStorage, $"{key}_sync_") { }
    public ValueTask<T?> GetSyncItemAsync(string clientId) => _localStorage.GetItemAsync<T?>(_key + clientId);
    public async ValueTask<IList<T>> GetAllSyncItemsAsync()
    {
        var items = new List<T>();
        var keys = await _localStorage.KeysAsync();
        foreach (var key in keys)
        {
            if (key.StartsWith(_key))
                items.Add((await _localStorage.GetItemAsync<T>(key)));
        }
        return items;
    }
    public async ValueTask<int> GetItemCountAsync()
    {
        var keys = await _localStorage.KeysAsync();
        return keys.Count(x => x.StartsWith(_key));
    }

    public ValueTask AddSyncItemAsync(T item, string clientId) =>
        _localStorage.SetItemAsync(_key + clientId, item);

    public ValueTask RemoveSyncItemAsync(string clientId) =>
        _localStorage.RemoveItemAsync(_key + clientId);

    public void SubscribeToChanges(Action<IList<T>> callback)
    {
        _localStorage.Changed += async (_, args) =>
        {
            if (args.Key.StartsWith(_key))
                callback((await GetAllSyncItemsAsync()));
        };
    }
}