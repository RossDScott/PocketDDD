using System.Net.Http.Json;
using Blazored.LocalStorage;
using Fluxor;
using MudBlazor;
using PocketDDD.BlazorClient.Services;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Features.Login.Store;

public class LoginEffects
{
    private readonly IState<LoginState> _state;
    private readonly ILocalStorageService _localStorage;
    private readonly IPocketDDDApiService _apiService;

    public LoginEffects(IState<LoginState> state, ILocalStorageService localStorage, IPocketDDDApiService apiService)
    {
        _state = state;
        _localStorage = localStorage;
        _apiService = apiService;
    }

    [EffectMethod]
    public async Task OnLogin(LoginAction action, IDispatcher dispatcher)
    {
        try
        {
            var result = await _apiService.Login(action.LoginName);
            ArgumentNullException.ThrowIfNull(result, nameof(result));

            await _localStorage.SetItemAsync("currentUser", result);
            dispatcher.Dispatch(new SetLoginSuccess(result));
        }
        catch
        {
            dispatcher.Dispatch(new SetLoginFailed());
        }
    }
}