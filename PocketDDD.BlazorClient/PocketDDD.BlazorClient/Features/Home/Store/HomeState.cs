using Fluxor;

namespace PocketDDD.BlazorClient.Features.Home.Store;

[FeatureState]
public record HomeState
{
    public bool Loading { get; init; } = false;
    public bool FailedToLoad { get; init; } = false;

    public int EventScore { get; init; } = 0;
}
