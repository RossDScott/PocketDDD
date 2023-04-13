using Fluxor;

namespace PocketDDD.BlazorClient.Features.Sync.Store;

public static class SyncReducer
{
    [ReducerMethod]
    public static SyncState OnSync(SyncState state, SyncAction action) =>
        state with { IsSyncing = true };

    [ReducerMethod]
    public static SyncState OnSyncCompleted(SyncState state, SyncCompletedAction action) =>
        state with { IsSyncing = false };

    [ReducerMethod]
    public static SyncState OnEventDataUpdated(SyncState state, EventDataUpdatedAction action) =>
        state with { EventDataVersion = action.EventData.Version };
}
