using PocketDDD.Shared.API.RequestDTOs;

namespace PocketDDD.BlazorClient.Features.Sync.Store;

public record SyncAction;

public record SetSyncingEventAction(bool Syncing);
public record SetSyncingEventFeedbackAction(bool Syncing);
public record SetSyncingSessionFeedbackAction(bool Syncing);
public record SetOutstandingEventFeedbackSyncCountAction(int Count);
public record SetOutstandingSessionFeedbackSyncCountAction(int Count);
