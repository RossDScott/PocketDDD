using Microsoft.EntityFrameworkCore;
using PocketDDD.Server.DB;
using PocketDDD.Server.Model.DBModel;
using PocketDDD.Server.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.Services;
public class PrizeDrawService
{
    private readonly PocketDDDContext dbContext;

    public PrizeDrawService(PocketDDDContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<PrizeDrawResponseDTO> GetWinners()
    {
        var allUsers = await dbContext.Users.ToListAsync();
        List<User> allEntries = new List<User>();

        foreach (var user in allUsers)
        {
            for (int i = 0; i < user.EventScore; i++)
            {
                allEntries.Add(user);
            }
        }

        var winningNumbers = new List<int>();
        var totalEntries = allEntries.Count();
        Random rnd = new();
        var selectCount = totalEntries > 30 ? 30 : totalEntries;

        for (int i = 0; i < selectCount; i++)
        {
            var number = rnd.Next(0, totalEntries - 1);
            if (!winningNumbers.Contains(number))
                winningNumbers.Add(number);
        }

        var winningPeople = new List<User>();
        foreach (var winningNumber in winningNumbers)
        {
            if (!winningPeople.Contains(allEntries[winningNumber]))
                winningPeople.Add(allEntries[winningNumber]);
        }

        var response = new PrizeDrawResponseDTO
        {
            TotalEntries = totalEntries,
            WinningNumbers = winningNumbers,
            Winners = winningPeople
        };

        return response;
    }
}
