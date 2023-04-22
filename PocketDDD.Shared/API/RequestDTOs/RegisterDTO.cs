using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Shared.API.RequestDTOs;
public record RegisterDTO
{
    public string Name { get; init; } = string.Empty;
}
