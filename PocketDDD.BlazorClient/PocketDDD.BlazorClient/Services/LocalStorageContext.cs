using Blazored.LocalStorage;
using System.Reflection;

namespace PocketDDD.BlazorClient.Services;

public abstract class LocalStorageContext
{
    private readonly ILocalStorageService _localStorage;

    public LocalStorageContext(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;

        initialiseKeys(typeof(KeyItem<>));
        initialiseKeys(typeof(KeyListItem<>));
        initialiseKeys(typeof(KeySyncItem<>));
    }

    private void initialiseKeys(Type keyType)
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

                ConstructorInfo constructor = genericType.GetConstructor(new Type[] { typeof(ILocalStorageService), typeof(string) });
                object instance = constructor.Invoke(new object[] { _localStorage, item.Name });
                item.SetValue(this, instance);
            });
    }
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
                callback((T)args.NewValue);
        };
    }
}

public class KeyListItem<T>
{
    private readonly ILocalStorageService _localStorage;
    private readonly string _key;

    public KeyListItem(ILocalStorageService localStorage, string key)
    {
        _localStorage = localStorage;
        _key = key;
    }

    public async ValueTask<List<T>> GetOrDefaultAsync() => 
        await _localStorage.GetItemAsync<List<T>>(_key) ?? new List<T>();

    public ValueTask SetAsync(List<T> list) => _localStorage.SetItemAsync(_key, list);

    public void SubscribeToChanges(Action<List<T>> callback)
    {
        _localStorage.Changed += (sender, args) =>
        {
            if (args.Key == _key)
                callback((List<T>)args.NewValue);
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

    public ValueTask RemoveSyncItemAsync(string clientId) =>
        _localStorage.RemoveItemAsync(_keyPrefix + clientId);

    public void SubscribeToChanges(Action<IList<T>> callback)
    {
        _localStorage.Changed += async (sender, args) =>
        {
            if (args.Key.StartsWith(_keyPrefix))
                callback((await GetAllSyncItemsAsync()));
        };
    }
}