using Fluxor;
using PocketDDD.BlazorClient.Features.EventScore.Store;
using PocketDDD.BlazorClient.Features.Security.Store;

namespace PocketDDD.BlazorClient.Features.Sync.Store;

public static class SyncReducer
{
    [ReducerMethod]
    public static SyncState OnSetSyncingEvent(SyncState state, SetSyncingEventAction action) =>
        state with { IsSyncingEvent = action.Syncing };

    [ReducerMethod]
    public static SyncState OnSetSyncingEventFeedback(SyncState state, SetSyncingEventFeedbackAction action) =>
        state with { IsSyncingEventFeedback = action.Syncing };

    [ReducerMethod]
    public static SyncState OnSetSyncingSessionFeedbackAction(SyncState state, SetSyncingSessionFeedbackAction action) =>
        state with { IsSyncingSessionFeedback = action.Syncing };

    [ReducerMethod]
    public static SyncState OnSetEventScore(SyncState state, SetEventScoreAction action) =>
        state with { EventScore = action.Score };

    [ReducerMethod]
    public static SyncState OnSetCurrentUser(SyncState state, SetCurrentUserAction action) =>
        state with { LoggedInUser = action.User };
}
