using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DTOs;
public class FeedbackResponseDTO
{
    public string ClientId { get; set; }
    public int Score { get; set; }
}
