using Fluxor;

namespace PocketDDD.BlazorClient.Features.Sync.Store;

[FeatureState]
public record SyncState
{
    public int EventDataVersion { get; init; } = 0;
    public bool IsSyncing { get; init; } = false;
}
