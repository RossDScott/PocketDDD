using Fluxor;

namespace PocketDDD.BlazorClient.Features.Home.Store;

[FeatureState]
public record HomeState
{
    public bool Loading { get; init; } = false;
    public bool FailedToLoad { get; init; } = false;

    public IEnumerable<TimeSlot> EventMetaData { get; init; } = Enumerable.Empty<TimeSlot>();

    public int EventScore { get; init; } = 0;
}

public record TimeSlot
{
    public int Id { get; init; }
    public DateTimeOffset From { get; init; }
    public DateTimeOffset To { get; init; }
    public string? Info { get; init; } = null;
    public IEnumerable<Session> Sessions { get; init; } = Enumerable.Empty<Session>();
}

public record Session
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string SpeakerName { get; init; } = string.Empty;
    public string TrackName { get; init; } = string.Empty;
    public string RoomName { get; init; } = string.Empty;
}

//export interface SessionItemVM
//{
//    session: SessionDTO, 
//    track: TrackDTO
//    isBookmarked: boolean;
//}

//export interface MetaDataVM
//{
//    timeSlots: TimeSlotVM[];
//}

//export interface TimeSlotVM
//{
//    id: number;
//    from: Date;
//    to: Date;
//    info: string;

//    sessions: SessionItemVM[];
//}