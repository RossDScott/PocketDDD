using Fluxor;
using PocketDDD.BlazorClient.Features.EventScore.Store;
using PocketDDD.BlazorClient.Features.Security.Store;

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
    public static SyncState OnSetEventScore(SyncState state, SetEventScoreAction action) =>
        state with { EventScore = action.Score };

    [ReducerMethod]
    public static SyncState OnSetCurrentUser(SyncState state, SetCurrentUserAction action) =>
        state with { LoggedInUser = action.User };

}
