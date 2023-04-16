using Fluxor;
using System.Collections.Immutable;

namespace PocketDDD.BlazorClient.Features.EventScore.Store;

[FeatureState]
public record EventScoreState
{
    public int Score { get; init; } = 0;
}
