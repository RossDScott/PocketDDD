using Fluxor;

namespace PocketDDD.BlazorClient.Features.SessionFeedback.Store;

[FeatureState]
public record SessionFeedbackState
{
    public int SessionId { get; init; }
}
