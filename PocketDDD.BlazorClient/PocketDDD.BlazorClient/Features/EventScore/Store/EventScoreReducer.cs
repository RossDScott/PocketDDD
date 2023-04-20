using Fluxor;
using PocketDDD.BlazorClient.Features.Home.Store;

namespace PocketDDD.BlazorClient.Features.EventScore.Store;

public static class EventScoreReducer
{
    [ReducerMethod]
    public static EventScoreState OnSetEventScore(EventScoreState state, SetEventScoreAction action) =>
        state with { Score = action.Score };

    [ReducerMethod]
    public static EventScoreState OnEventScoreUpdated(EventScoreState state, EventScoreUpdatedAction action) =>
        state with { Score = action.Score };
}
