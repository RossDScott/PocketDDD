using Fluxor;

namespace PocketDDD.BlazorClient.Features.HeaderBar.Store;

[FeatureState]
public record HeaderBarState
{
    public string Title { get; init; } = string.Empty;
    public bool ShowBackButton { get; init; } = false;
}
