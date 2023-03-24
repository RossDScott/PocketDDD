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
    private readonly LocalStorageService _localStorage;
    private readonly IPocketDDDApiService _pocketDDDAPI;

    public LoginEffects(IState<LoginState> state, LocalStorageService localStorage, IPocketDDDApiService pocketDDDAPI)
    {
        _state = state;
        _localStorage = localStorage;
        _pocketDDDAPI = pocketDDDAPI;
    }

    [EffectMethod]
    public async Task OnLogin(LoginAction action, IDispatcher dispatcher)
    {
        try
        {
            var result = await _pocketDDDAPI.Login(action.LoginName);
            ArgumentNullException.ThrowIfNull(result, nameof(result));

            await _localStorage.SetCurrentUser(result);
            dispatcher.Dispatch(new SetLoginSuccess(result));
        }
        catch
        {
            dispatcher.Dispatch(new SetLoginFailed());
        }
    }
}