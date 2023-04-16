using System.Net.Http.Json;
using Blazored.LocalStorage;
using Fluxor;
using MudBlazor;
using PocketDDD.BlazorClient.Features.Home.Store;
using PocketDDD.BlazorClient.Services;
using static MudBlazor.CategoryTypes;

namespace PocketDDD.BlazorClient.Features.Security.Store;

public class SecurityEffects
{
    private readonly IState<SecurityState> _state;
    private readonly LocalStorageService _localStorage;
    private readonly IPocketDDDApiService _pocketDDDAPI;
    private readonly IDialogService _dialog;

    private IDialogReference? currentDialogReference = null; 

    public SecurityEffects(IState<SecurityState> state, LocalStorageService localStorage, IPocketDDDApiService pocketDDDAPI, IDialogService dialog)
    {
        _state = state;
        _localStorage = localStorage;
        _pocketDDDAPI = pocketDDDAPI;
        _dialog = dialog;
    }

    [EffectMethod]
    public async Task OnCheckUser(CheckUserAction action, IDispatcher dispatcher)
    {
        var user = await _localStorage.CurrentUser.GetAsync();

        if (user is not null)
        {
            dispatcher.Dispatch(new SetCurrentUserAction(user));
            return;
        }

        if (currentDialogReference is null)
            currentDialogReference = _dialog.Show<Features.Security.Components.Login>("", new DialogOptions { FullScreen = true });
    }

    [EffectMethod]
    public async Task OnLogin(LoginAction action, IDispatcher dispatcher)
    {
        try
        {
            var result = await _pocketDDDAPI.Login(action.LoginName);
            ArgumentNullException.ThrowIfNull(result, nameof(result));

            await _localStorage.CurrentUser.SetAsync(result);
            dispatcher.Dispatch(new SetLoginSuccessAction(result));
        }
        catch
        {
            dispatcher.Dispatch(new SetLoginFailed());
        }
    }

    [EffectMethod]
    public Task OnLoginSuccess(SetLoginSuccessAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetCurrentUserAction(action.User));
        currentDialogReference?.Close();
        currentDialogReference = null;
        return Task.CompletedTask;
    }
}