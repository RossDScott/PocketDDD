using Microsoft.AspNetCore.Mvc;
using PocketDDD.Server.Services;
using PocketDDD.Shared.API.RequestDTOs;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.Server.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EventDataController : ControllerBase
{
    private readonly EventDataService eventDataService;
    private readonly SessionizeService sessionizeService;
    private readonly IConfiguration configuration;

    public EventDataController(EventDataService eventDataService, SessionizeService sessionizeService, IConfiguration configuration)
    {
        this.eventDataService = eventDataService;
        this.sessionizeService = sessionizeService;
        this.configuration = configuration;
    }

    [HttpPost("[Action]")]
    public Task<EventDataResponseDTO?> FetchLatestEventData(EventDataUpdateRequestDTO requestDTO)
    {
        return eventDataService.FetchLatestEventData(requestDTO);
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> RefreshFromSessionize()
    {
        string token = Request.Headers["Authorization"];
        if (token != configuration["AdminKey"])
            return Unauthorized();

        await sessionizeService.UpdateFromSessionize();
        return Ok();
    }
}
