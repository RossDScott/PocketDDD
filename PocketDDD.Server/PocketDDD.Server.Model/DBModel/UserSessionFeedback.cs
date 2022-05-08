using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DBModel;
public class UserSessionFeedback
{
    public int Id { get; set; }
    public DateTimeOffset DateTimestamp { get; set; }

    public int EventDetailId { get; set; }
    public EventDetail EventDetail { get; set; }

    public int SessionId { get; set; }
    public Session Session { get; set; }
    

    public int? SpeakerKnowledgeRating { get; set; }
    public int? SpeakerSkillsRating { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public string Comment { get; set; }
}
