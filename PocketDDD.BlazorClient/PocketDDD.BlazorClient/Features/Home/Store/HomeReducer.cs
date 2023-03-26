using Fluxor;

namespace PocketDDD.BlazorClient.Features.Home.Store;

public static class HomeReducer
{
    [ReducerMethod]
    public static HomeState OnLoadData(HomeState state, LoadDataAction action) =>
        state with { Loading = true, FailedToLoad = false };
}
