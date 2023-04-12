using Fluxor;
using PocketDDD.BlazorClient.Features.Home.Store;

namespace PocketDDD.BlazorClient.Features.HeaderBar.Store;

public static class HeaderBarReducer
{
    [ReducerMethod]
    public static HeaderBarState OnSetHeaderBarTitle(HeaderBarState state, SetHeaderBarTitleAction action) =>
        state with { Title = action.Title };

    [ReducerMethod]
    public static HeaderBarState OnSetBackButtonVisability(HeaderBarState state, SetBackButtonVisabilityAction action) =>
        state with { ShowBackButton = action.Visable };

    [ReducerMethod]
    public static HeaderBarState OnNavigateBackAction(HeaderBarState state, NavigateBackAction action) =>
        state with { ShowBackButton = false };
    
}
