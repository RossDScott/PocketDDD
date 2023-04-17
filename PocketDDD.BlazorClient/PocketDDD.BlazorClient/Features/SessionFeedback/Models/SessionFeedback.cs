namespace PocketDDD.BlazorClient.Features.SessionFeedback.Models;

public record SessionFeedback
{
    public int SessionId { get; init; }
    public int SpeakerKnowledgeRating { get; init; }
    public int SpeakingSkillRating { get; init; }
    public string Comments { get; init; } = string.Empty;
}
