using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketDDD.Server.Model.DTOs;
using PocketDDD.Server.Services;

namespace PocketDDD.Server.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EventDataController : ControllerBase
{
    private readonly EventDataService eventDataService;

    public EventDataController(EventDataService eventDataService)
    {
        this.eventDataService = eventDataService;
    }

    [HttpPost("[Action]")]
    public Task<EventDataResponseDTO?> FetchLatestEventData(EventDataUpdateRequestDTO requestDTO)
    {
        return eventDataService.FetchLatestEventData(requestDTO);
    }
}
