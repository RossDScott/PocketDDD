using Fluxor;
using PocketDDD.BlazorClient.Features.Sync.Store;

namespace PocketDDD.BlazorClient.Features.Home.Store;

public static class HomeReducer
{
    [ReducerMethod]
    public static HomeState OnLoadData(HomeState state, LoadDataAction action) =>
        state with { Loading = true, FailedToLoad = false };

    [ReducerMethod]
    public static HomeState OnSetEventData(HomeState state, SetEventMetaDataAction action) =>
        state with 
        { 
            Loading = false, 
            FailedToLoad = false, 
            EventMetaData = action.EventData.ToHomeStateModel() 
        };

    [ReducerMethod]
    public static HomeState OnEventDataUpdated(HomeState state, EventDataUpdatedAction action) =>
        state with
        {
            Loading = false,
            FailedToLoad = false,
            EventMetaData = action.EventData.ToHomeStateModel()
        };


}
