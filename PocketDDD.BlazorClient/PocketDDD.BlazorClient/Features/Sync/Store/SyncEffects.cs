using System.ComponentModel.DataAnnotations;
using Fluxor;
using PocketDDD.BlazorClient.Features.EventScore.Store;
using PocketDDD.BlazorClient.Services;
using PocketDDD.Shared.API.RequestDTOs;

namespace PocketDDD.BlazorClient.Features.Sync.Store;

public class SyncEffects
{
    private readonly IState<SyncState> _state;
    private readonly LocalStorageContext _localStorage;
    private readonly IPocketDDDApiService _pocketDDDAPI;

    public SyncEffects(IState<SyncState> state, IDispatcher dispatcher, LocalStorageContext localStorage, IPocketDDDApiService pocketDDDAPI)
    {
        _state = state;
        _localStorage = localStorage;
        _pocketDDDAPI = pocketDDDAPI;

        _localStorage.EventFeedbackSync.SubscribeToChanges(
            items => dispatcher.Dispatch(new SyncEventFeedbackItemsAction(items)));
        _localStorage.SessionFeedbackSync.SubscribeToChanges(
            items => dispatcher.Dispatch(new SyncSessionFeedbackItemsAction(items)));
    }

    [EffectMethod]
    public async Task OnSync(SyncAction action, IDispatcher dispatcher)
    {
        try
        {
            var eventData = await _localStorage.EventData.GetAsync();
            var eventDataVersion = eventData?.Version ?? 0;

            try
            {
                var newEventData = await _pocketDDDAPI.FetchLatestEventData(new EventDataUpdateRequestDTO { Version = eventDataVersion });

                if (newEventData is not null)
                {
                    await _localStorage.EventData.SetAsync(newEventData);
                }
            }
            catch
            {
                // ignored
            }

            var eventFeedbackItems = await _localStorage.EventFeedbackSync.GetAllSyncItemsAsync();
            var sessionFeedbackItems = await _localStorage.SessionFeedbackSync.GetAllSyncItemsAsync();

            dispatcher.Dispatch(new SyncEventFeedbackItemsAction(eventFeedbackItems));
            dispatcher.Dispatch(new SyncSessionFeedbackItemsAction(sessionFeedbackItems));
        }
        catch
        {
            // ignored
        }
        finally
        {
            dispatcher.Dispatch(new SyncCompletedAction());
        }
    }

    [EffectMethod]
    public async Task OnSyncEventFeedbackItems(SyncEventFeedbackItemsAction action, IDispatcher dispatcher)
    {
        var syncItems = action.syncItems;
        foreach (var item in syncItems)
        {
            try
            {
                var result = await _pocketDDDAPI.SubmitClientEventFeedback(item);
                await _localStorage.EventFeedbackSync.RemoveSyncItemAsync(result.ClientId);
                dispatcher.Dispatch(new EventScoreUpdatedAction(result.Score));
            }
            catch
            {
                // ignored
            }
        }
    }

    [EffectMethod]
    public async Task OnSyncSessionFeedbackItems(SyncSessionFeedbackItemsAction action, IDispatcher dispatcher)
    {
        var syncItems = action.syncItems;
        foreach (var item in syncItems)
        {
            try
            {
                var result = await _pocketDDDAPI.SubmitClientSessionFeedback(item);
                await _localStorage.SessionFeedbackSync.RemoveSyncItemAsync(result.ClientId);
                dispatcher.Dispatch(new EventScoreUpdatedAction(result.Score));
            }
            catch
            {
                // ignored
            }
        }
    }
}
