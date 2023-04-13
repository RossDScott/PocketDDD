using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Features.Home.Store;

public record LoadDataAction();
public record SetUserLoggedInAction();
public record SetEventMetaDataAction(EventDataResponse EventData, IList<int> SessionBookmarks);
