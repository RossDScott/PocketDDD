using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Features.Sync.Store;

public record SyncAction();
public record SubmitSyncItemsAction();
public record SyncCompletedAction();
public record SetEventDataVersionAction(int Version);
