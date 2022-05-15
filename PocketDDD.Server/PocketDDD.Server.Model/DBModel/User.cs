using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DBModel;

public class User
{
    public const string UserIdClaim = "UserId";
    public int Id { get; set; }
    public int EventDetailId { get; set; }
    public string Name { get; set; }
    public string Token { get; set; }
    public int EventScore { get; set; }
}
