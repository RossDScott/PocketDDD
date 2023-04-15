namespace PocketDDD.BlazorClient.Features.EventFeedback.Models;

public record EventFeedback
{
    public int Refreshments { get; set; }
    public int Venue { get; set; }
    public int Overall { get; set; }
    public string Comments { get; set; } = string.Empty;
}
