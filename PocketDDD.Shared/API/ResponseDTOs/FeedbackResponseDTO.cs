using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Shared.API.ResponseDTOs;
public record FeedbackResponseDTO
{
    public string ClientId { get; init; }
    public int Score { get; init; }
}