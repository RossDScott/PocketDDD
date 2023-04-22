using PocketDDD.Shared.API.RequestDTOs;

namespace PocketDDD.BlazorClient.Features.Sync.Store;

public record SyncAction;
public record SyncEventAction;
public record SyncEventFeedbackAction;
public record SyncSessionFeedbackAction;

public record SyncEventFeedbackItemsAction(IList<SubmitEventFeedbackDTO> SyncItems);
public record SyncSessionFeedbackItemsAction(IList<SubmitSessionFeedbackDTO> SyncItems);

public record SetSyncingEventAction(bool Syncing);
public record SetSyncingEventFeedbackAction(bool Syncing);
public record SetSyncingSessionFeedbackAction(bool Syncing);
