using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DTOs;
public class SessionFeedbackDTO
{
    public string ClientId { get; set; }
    public DateTimeOffset DateTimeStamp { get; set; }
    public int SessionId { get; set; }
    public int KnowlegeRating { get; set; }
    public int SpeakingSkillRating { get; set; }
    public string Comments { get; set; }
}
