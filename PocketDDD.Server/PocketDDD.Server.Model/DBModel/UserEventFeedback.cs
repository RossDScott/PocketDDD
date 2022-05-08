using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DBModel;
public class UserEventFeedback
{
    public int Id { get; set; }
    public DateTimeOffset DateTimestamp { get; set; }

    public int EventDetailId { get; set; }
    public EventDetail EventDetail { get; set; }
    
    public int? Refreshments { get; set; }
    public int? Venue { get; set; }
    public int? Overall { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    
    public string Comment { get; set; }
}
