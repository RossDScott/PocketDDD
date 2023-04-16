using Fluxor;
using PocketDDD.BlazorClient.Services;
using PocketDDD.Shared.API.RequestDTOs;

namespace PocketDDD.BlazorClient.Features.Sync.Store;

public class SyncEffects
{
    private readonly IState<SyncState> _state;
    private readonly LocalStorageService _localStorage;
    private readonly IPocketDDDApiService _pocketDDDAPI;

    public SyncEffects(IState<SyncState> state, IDispatcher dispatcher, LocalStorageService localStorage, IPocketDDDApiService pocketDDDAPI)
    {
        _state = state;
        _localStorage = localStorage;
        _pocketDDDAPI = pocketDDDAPI;

        _localStorage.EventFeedbackSync.SubscribeToChanges(
            items => dispatcher.Dispatch(new SyncEventFeedbackItemsAction(items)));
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
                await _localStorage.EventData.SetAsync(newEventData);
                dispatcher.Dispatch(new SetEventDataVersionAction(newEventData.Version));
            }
        }
        finally
        {
            dispatcher.Dispatch(new SyncCompletedAction());
        }
    }

    [EffectMethod]
    public async Task SubmitSyncItems(SyncEventFeedbackItemsAction action, IDispatcher dispatcher)
    {
        var items = action.syncItems;

        
    }
}
