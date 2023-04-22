using PocketDDD.Shared.API.RequestDTOs;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Features.Sync.Store;

public record SyncAction();
public record SyncEventFeedbackItemsAction(IList<SubmitEventFeedbackDTO> syncItems);
public record SyncSessionFeedbackItemsAction(IList<SubmitSessionFeedbackDTO> syncItems);
public record SyncCompletedAction();
