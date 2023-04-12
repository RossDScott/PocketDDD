using Fluxor;
using PocketDDD.BlazorClient.Features.Home.Store;
using PocketDDD.BlazorClient.Features.Login.Store;
using PocketDDD.BlazorClient.Services;
using PocketDDD.Shared.API.RequestDTOs;

namespace PocketDDD.BlazorClient.Features.Sync.Store;

public class SyncEffects
{
    private readonly IState<SyncState> _state;
    private readonly LocalStorageService _localStorage;
    private readonly IPocketDDDApiService _pocketDDDAPI;

    public SyncEffects(IState<SyncState> state, LocalStorageService localStorage, IPocketDDDApiService pocketDDDAPI)
    {
        _state = state;
        _localStorage = localStorage;
        _pocketDDDAPI = pocketDDDAPI;
    }

    [EffectMethod]
    public async Task OnSync(SyncAction action, IDispatcher dispatcher)
    {
        try
        {
            var metaDataVersion = _state.Value.EventDataVersion;
            var newEventData = await _pocketDDDAPI.FetchLatestEventData(new EventDataUpdateRequest { Version = metaDataVersion });
            if (newEventData is not null)
            {
                await _localStorage.SetEventData(newEventData);
                dispatcher.Dispatch(new EventDataUpdatedAction(newEventData));
                dispatcher.Dispatch(new LoadDataAction());
            }
        }
        finally
        {
            dispatcher.Dispatch(new SyncCompletedAction());
        }
    }
}
