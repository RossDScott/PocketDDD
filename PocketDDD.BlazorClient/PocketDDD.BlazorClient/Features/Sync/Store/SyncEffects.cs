using Fluxor;
using PocketDDD.BlazorClient.Features.Sync.Services;
using PocketDDD.BlazorClient.Services;

namespace PocketDDD.BlazorClient.Features.Sync.Store;

public class SyncEffects
{
    private readonly SyncService _syncService;
    private readonly LocalStorageContext _localStorage;

    public SyncEffects(SyncService syncService, LocalStorageContext localStorage)
    {
        _syncService = syncService;
        _localStorage = localStorage;

        _localStorage.EventFeedbackSync.SubscribeToChanges(
            async items => await _syncService.SyncEventFeedbackItems(items));

        _localStorage.SessionFeedbackSync.SubscribeToChanges(
            async items => await _syncService.SyncSessionFeedbackItems(items));
    }

    [EffectMethod]
    public Task OnSync(SyncAction action, IDispatcher dispatcher) =>
        _syncService.SyncAll();
}
