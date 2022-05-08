using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DBModel;

public class Track
{
    public int Id { get; set; }
    public EventDetail EventDetail { get; set; }
    public string Name { get; set; }
    public string RoomName { get; set; }
}
