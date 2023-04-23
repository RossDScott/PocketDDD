using Fluxor;
using PocketDDD.BlazorClient.Features.Sync.Store;
using PocketDDD.BlazorClient.Services;
using PocketDDD.Shared.API.RequestDTOs;

namespace PocketDDD.BlazorClient.Features.Sync.Services;

public class SyncService
{
    private readonly IDispatcher _dispatcher;
    private readonly LocalStorageContext _localStorage;
    private readonly IPocketDDDApiService _pocketDDDAPI;

    public SyncService(IDispatcher dispatcher, LocalStorageContext localStorage, IPocketDDDApiService pocketDDDAPI)
    {
        _dispatcher = dispatcher;
        _localStorage = localStorage;
        _pocketDDDAPI = pocketDDDAPI;
    }

    public async Task SyncAll()
    {
        var syncEvent = SyncEvent();
        var syncEventFeedback = SyncEventFeedback();
        var syncSessionFeedback = SyncSessionFeedback();

        await Task.WhenAll(syncEvent, syncEventFeedback, syncSessionFeedback);
    }

    public async Task SyncEvent()
    {
        _dispatcher.Dispatch(new SetSyncingEventAction(true));

        try
        {
            var eventData = await _localStorage.EventData.GetAsync();
            var eventDataVersion = eventData?.Version ?? 0;

            var newEventData = await _pocketDDDAPI.FetchLatestEventData(new EventDataUpdateRequestDTO { Version = eventDataVersion });

            if (newEventData is not null)
                await _localStorage.EventData.SetAsync(newEventData);
        }
        catch
        {
            // ignored
        }
        finally
        {
            _dispatcher.Dispatch(new SetSyncingEventAction(false));
        }
    }

    public async Task SyncEventFeedback()
    {
        try
        {
            var syncItems = await _localStorage.EventFeedbackSync.GetAllSyncItemsAsync();
            await SyncEventFeedbackItems(syncItems);
        }
        catch
        {
            // ignored
        }
    }

    public async Task SyncEventFeedbackItems(IList<SubmitEventFeedbackDTO> syncItems)
    {
        _dispatcher.Dispatch(new SetSyncingEventFeedbackAction(true));

        try
        {
            foreach (var item in syncItems)
            {
                try
                {
                    var result = await _pocketDDDAPI.SubmitClientEventFeedback(item);
                    await _localStorage.EventFeedbackSync.RemoveSyncItemAsync(result.ClientId);
                    await _localStorage.EventScore.SetAsync(result.Score);
                }
                catch
                {
                    // ignored
                }
            }
        }
        finally
        {
            _dispatcher.Dispatch(new SetSyncingEventFeedbackAction(false));
        }
    }

    public async Task SyncSessionFeedback()
    {
        try
        {
            var syncItems = await _localStorage.SessionFeedbackSync.GetAllSyncItemsAsync();
            await SyncSessionFeedbackItems(syncItems);
        }
        catch
        {
            // ignored
        }
    }

    public async Task SyncSessionFeedbackItems(IList<SubmitSessionFeedbackDTO> syncItems)
    {
        _dispatcher.Dispatch(new SetSyncingSessionFeedbackAction(true));

        try
        {
            foreach (var item in syncItems)
            {
                try
                {
                    var result = await _pocketDDDAPI.SubmitClientSessionFeedback(item);
                    await _localStorage.SessionFeedbackSync.RemoveSyncItemAsync(result.ClientId);
                    await _localStorage.EventScore.SetAsync(result.Score);
                }
                catch
                {
                    // ignored
                }
            }
        }
        finally
        {
            _dispatcher.Dispatch(new SetSyncingSessionFeedbackAction(false));
        }
    }

}
