using PocketDDD.Server.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Model.DTOs;
public class PrizeDrawResponseDTO
{
    public int TotalEntries { get; set; }
    public IEnumerable<int> WinningNumbers { get; set; }
    public IEnumerable<User> Winners { get; set; }
}
