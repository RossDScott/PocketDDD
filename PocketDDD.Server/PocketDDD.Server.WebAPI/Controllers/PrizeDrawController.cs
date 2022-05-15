using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketDDD.Server.Model.DTOs;
using PocketDDD.Server.Services;

namespace PocketDDD.Server.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PrizeDrawController : ControllerBase
{
    private readonly PrizeDrawService prizeDrawService;
    private readonly IConfiguration configuration;

    public PrizeDrawController(PrizeDrawService prizeDrawService, IConfiguration configuration)
    {
        this.prizeDrawService = prizeDrawService;
        this.configuration = configuration;
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> Winners()
    {
        string token = Request.Headers["Authorization"];
        if (token != configuration["AdminKey"])
            return Unauthorized();

        var winners = await prizeDrawService.FetchWinners();
        return Ok(winners);
    }
}
