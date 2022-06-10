using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketDDD.Server.Services;

namespace PocketDDD.Server.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SpeakerController : ControllerBase
{
    private readonly SpeakersService speakersService;

    public SpeakerController(SpeakersService speakersService)
    {
        this.speakersService = speakersService;
    }

    [HttpGet("[Action]/{token}")]
    public async Task<IActionResult> Feedback(Guid token)
    {
        var feedback = await speakersService.FetchFeedback(token);

        if (feedback is null)
            return Unauthorized();

        return Ok(feedback);
    }
}
