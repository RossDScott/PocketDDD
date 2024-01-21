namespace PocketDDD.Server.Model.DBModel;

public class Track
{
    public int Id { get; set; }
    public int SessionizeId { get; set; }
    public EventDetail EventDetail { get; set; }
    public string Name { get; set; }
    public string RoomName { get; set; }
}
