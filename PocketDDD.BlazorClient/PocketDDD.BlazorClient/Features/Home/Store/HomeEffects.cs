using Fluxor;
using MudBlazor;
using PocketDDD.BlazorClient.Features.Session.Store;
using PocketDDD.BlazorClient.Features.Sync.Store;
using PocketDDD.BlazorClient.Services;
using PocketDDD.Shared.API.RequestDTOs;
using System.Collections.ObjectModel;
using EventDataUpdatedAction = PocketDDD.BlazorClient.Services.EventDataUpdatedAction;

namespace PocketDDD.BlazorClient.Features.Home.Store;

public class HomeEffects
{
    private readonly IState<HomeState> _state;
    private readonly LocalStorageService _localStorage;
    private readonly IPocketDDDApiService _pocketDDDAPI;
    private readonly IDialogService _dialog;

    public HomeEffects(IState<HomeState> state, IDispatcher dispatcher, LocalStorageService localStorage, 
                        IPocketDDDApiService pocketDDDAPI, IDialogService dialog)
    {
        _state = state;
        _localStorage = localStorage;
        _pocketDDDAPI = pocketDDDAPI;
        _dialog = dialog;

        _localStorage.EventData.SubscribeToChanges(
            _ => dispatcher.Dispatch(new LoadDataAction()));
        _localStorage.SessionBookmarks.SubscribeToChanges(
            _ => dispatcher.Dispatch(new LoadDataAction()));
    }

    [EffectMethod]
    public async Task OnLoadData(LoadDataAction action, IDispatcher dispatcher)
    {
        var eventData = await _localStorage.EventData.GetAsync();
        var sessionBookmarks = await _localStorage.SessionBookmarks.GetOrDefaultAsync(() => new Collection<int>());

        if (eventData is not null)
            dispatcher.Dispatch(new SetEventMetaDataAction(eventData, sessionBookmarks));
    }
}
