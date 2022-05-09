using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DTOs;
public class RegisterResponseDTO
{
    public string Name { get; set; }
    public string BearerToken { get; set; }
}
