using System.Net.Http.Json;
using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PocketDDD.BlazorClient.Features.EventScore.Store;
using PocketDDD.BlazorClient.Features.Home.Store;
using PocketDDD.BlazorClient.Services;
using static MudBlazor.CategoryTypes;

namespace PocketDDD.BlazorClient.Features.Security.Store;

public class SecurityEffects
{
    private readonly IState<SecurityState> _state;
    private readonly LocalStorageContext _localStorage;
    private readonly IPocketDDDApiService _pocketDDDAPI;
    private readonly IDialogService _dialog;
    private readonly NavigationManager _navigationManager;
    private IDialogReference? currentDialogReference = null; 

    public SecurityEffects(IState<SecurityState> state, LocalStorageContext localStorage, 
            IPocketDDDApiService pocketDDDAPI, IDialogService dialog, NavigationManager navigationManager)
    {
        _state = state;
        _localStorage = localStorage;
        _pocketDDDAPI = pocketDDDAPI;
        _dialog = dialog;
        _navigationManager = navigationManager;
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
            await _localStorage.EventScore.SetAsync(1);

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

    [EffectMethod]
    public Task OnLoginSuccess(SetCurrentUserAction action, IDispatcher dispatcher)
    {
        _pocketDDDAPI.SetUserAuthToken(action.User.Token);
        return Task.CompletedTask;
    }

    [EffectMethod]
    public async Task DeleteAllDataAndLogOut(DeleteAllDataAndLogOutAction action, IDispatcher dispatcher)
    {
        await _localStorage.DeleteAllDataAsync();
        _navigationManager.NavigateTo("/", true);
    }
}