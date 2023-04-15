using Fluxor;
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
            var newEventData = await _pocketDDDAPI.FetchLatestEventData(new EventDataUpdateRequestDTO { Version = metaDataVersion });
            if (newEventData is not null)
            {
                await _localStorage.SetEventData(newEventData);
                dispatcher.Dispatch(new SetEventDataVersionAction(newEventData.Version));
            }
        }
        finally
        {
            dispatcher.Dispatch(new SyncCompletedAction());
        }
    }

    [EffectMethod]
    public async Task SubmitSyncItems(SubmitSyncItemsAction action, IDispatcher dispatcher)
    {
        var items = await _localStorage.GetEventData();
    }
}
