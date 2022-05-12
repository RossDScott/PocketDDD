using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DTOs;
public class EventFeedbackDTO
{
    public string ClientId { get; set; }
    public DateTime DateTimeStamp { get; set; }
    public int RefreshmentsRating { get; set; }
    public int VenueRating { get; set; }
    public int Overall { get; set; }
    public string Comments { get; set; }
}
