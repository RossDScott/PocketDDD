using Fluxor;
using MudBlazor;
using PocketDDD.BlazorClient.Features.Sync.Store;
using PocketDDD.BlazorClient.Services;
using PocketDDD.Shared.API.RequestDTOs;

namespace PocketDDD.BlazorClient.Features.Home.Store;

public class HomeEffects
{
    private readonly IState<HomeState> _state;
    private readonly LocalStorageService _localStorage;
    private readonly IPocketDDDApiService _pocketDDDAPI;
    private readonly IDialogService _dialog;

    public HomeEffects(IState<HomeState> state, LocalStorageService localStorage, 
                        IPocketDDDApiService pocketDDDAPI, IDialogService dialog)
    {
        _state = state;
        _localStorage = localStorage;
        _pocketDDDAPI = pocketDDDAPI;
        _dialog = dialog;
    }

    [EffectMethod]
    public async Task OnCheckUser(CheckUserAction action, IDispatcher dispatcher)
    {
        var user = await _localStorage.GetCurrentUser();
        if (user is null)
        {
            _dialog.Show<Features.Login.Components.Login>("", new DialogOptions { FullScreen = true });
        }
        else
        {
            dispatcher.Dispatch(new SetCurrentUser(user));
        }

        
    }

    [EffectMethod]
    public async Task OnLoadData(LoadDataAction action, IDispatcher dispatcher)
    {
        var eventData = await _localStorage.GetEventData();
        var sessionBookmarks = await _localStorage.GetSessionBookmarks();

        if (eventData is not null)
            dispatcher.Dispatch(new SetEventMetaDataAction(eventData, sessionBookmarks));
    }
}
