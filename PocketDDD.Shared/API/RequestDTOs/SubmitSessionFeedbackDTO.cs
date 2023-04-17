using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Shared.API.RequestDTOs;
public record SubmitSessionFeedbackDTO
{
    public string ClientId { get; init; } = Guid.NewGuid().ToString();
    public DateTimeOffset CreatedOn { get; init; }
    public int SessionId { get; init; }
    public int SpeakerKnowledgeRating { get; init; }
    public int SpeakingSkillRating { get; init; }
    public string Comments { get; init; } = string.Empty;
}