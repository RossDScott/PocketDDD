using Blazored.LocalStorage;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Services;

public class LocalStorageService
{
    private readonly ILocalStorageService _localStorage;

    public LocalStorageService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public ValueTask SetCurrentUser(LoginResult loginResult) => _localStorage.SetItemAsync("currentUser", loginResult);
}
