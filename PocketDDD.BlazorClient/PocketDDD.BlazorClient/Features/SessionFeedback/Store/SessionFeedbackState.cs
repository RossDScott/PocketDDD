using Fluxor;

namespace PocketDDD.BlazorClient.Features.SessionFeedback.Store;

[FeatureState]
public record SessionFeedbackState
{
    public string SessionTitle { get; set; } = string.Empty;
    public string SpeakerName { get; set; } = string.Empty;
    public bool TimeSlotAlreadyHasFeedback { get; init; } = false;
}
