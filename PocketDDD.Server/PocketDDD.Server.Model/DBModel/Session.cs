using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DBModel;
public class Session
{
    public int Id { get; set; }
    public EventDetail EventDetail { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string FullDescription { get; set; }
    public string Speaker { get; set; }
    public virtual Track Track { get; set; }
    public virtual TimeSlot TimeSlot { get; set; }
    public Guid SpeakerToken { get; set; }
}
