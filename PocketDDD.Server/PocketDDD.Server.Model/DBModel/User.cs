using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DBModel;

public class User
{
    public int Id { get; set; }
    public int EventDetailId { get; set; }
    public string GivenName { get; set; }
    public string FamilyName { get; set; }
    public string Token { get; set; }
    public int EventScore { get; set; }
}
