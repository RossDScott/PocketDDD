using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DTOs;
public class EventDataResponseDTO
{
    public int Version { get; set; }
    public IEnumerable<TimeSlotDTO> TimeSlots { get; set; }
    public IEnumerable<TrackDTO> Tracks { get; set; }
    public IEnumerable<SessionDTO> Sessions { get; set; }
}

public class TimeSlotDTO
{
    public int Id { get; set; }
    public DateTimeOffset From { get; set; }
    public DateTimeOffset To { get; set; }
    public string? Info { get; set; }
}

public class TrackDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string RoomName { get; set; }
}

public class SessionDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string FullDescription { get; set; }
    public string Speaker { get; set; }
    public int TrackId { get; set; }
    public int TimeSlotId { get; set; }
}
