using Fluxor;

namespace PocketDDD.BlazorClient.Features.Session.Store;

[FeatureState]
public record SessionState
{
    public Session? Session { get; init; } = null;
}

public record Session
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
    public string SpeakerName { get; init; } = string.Empty;

    public DateTimeOffset From { get; set; }
    public DateTimeOffset To { get; set; }

    public string TrackName { get; init; } = string.Empty;
    public string RoomName { get; init; } = string.Empty;
    public bool IsBookmarked { get; set; } = false;
}