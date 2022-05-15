using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DTOs;
public class SpeakerFeedbackResponseDTO
{
    public string SpeakerName { get; set; }
    public string SessionTitle { get; set; }
    public IEnumerable<SpeakerFeedbackItem> Feedback { get; set; }

    public decimal AverageKnowledgeRating { get; set; }
    public decimal AverageSkillRating { get; set; }
}

public class SpeakerFeedbackItem
{
    public int? SpeakerKnowledgeRating { get; set; }
    public int? SpeakerSkillsRating { get; set; }

    public string Comment { get; set; }
}
