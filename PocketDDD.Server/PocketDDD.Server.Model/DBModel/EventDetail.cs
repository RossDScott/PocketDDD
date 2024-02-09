namespace PocketDDD.Server.Model.DBModel;

public class EventDetail
{
    public int Id { get; set; }
    public string SessionizeId { get; set; }
    public int Version { get; set; }
    public ICollection<Track> Tracks { get; set; }
    public ICollection<TimeSlot> TimeSlots { get; set; }
    public ICollection<Session> Sessions { get; set; }
}
