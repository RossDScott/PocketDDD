using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Shared.API.ResponseDTOs;
public record EventDataResponse
{
    public int Version { get; set; }
    public IEnumerable<TimeSlot> TimeSlots { get; set; } = Enumerable.Empty<TimeSlot>();
    public IEnumerable<Track> Tracks { get; set; } = Enumerable.Empty<Track>();
    public IEnumerable<Session> Sessions { get; set; } = Enumerable.Empty<Session>();
}

public record TimeSlot
{
    public int Id { get; set; }
    public DateTimeOffset From { get; set; }
    public DateTimeOffset To { get; set; }
    public string? Info { get; set; }
}

public record Track
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string RoomName { get; set; } = "";
}

public class Session
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string ShortDescription { get; set; } = "";
    public string FullDescription { get; set; } = "";
    public string Speaker { get; set; } = "";
    public int TrackId { get; set; }
    public int TimeSlotId { get; set; }
}
