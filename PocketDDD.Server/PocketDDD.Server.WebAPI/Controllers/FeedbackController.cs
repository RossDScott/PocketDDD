using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketDDD.Server.Model.DTOs;
using PocketDDD.Server.Services;

namespace PocketDDD.Server.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FeedbackController : ControllerBase
{
    private readonly UserService userService;
    private readonly FeedbackService feedbackService;

    public FeedbackController(UserService userService, FeedbackService feedbackService)
    {
        this.userService = userService;
        this.feedbackService = feedbackService;
    }

    [HttpPost("Action")]
    public async Task<IActionResult> ClientSessionFeedback(SessionFeedbackDTO feedbackDTO)
    {
        string token = Request.Headers["Authorization"];
        var user = await userService.FetchUserByToken(token);
        if (user == null)
            return Unauthorized();

        var response = await feedbackService.SubmitClientSessionFeedback(feedbackDTO, user);
        return Ok(response);
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> ClientEventData(EventFeedbackDTO feedbackDTO)
    {
        string token = Request.Headers["Authorization"];
        var user = await userService.FetchUserByToken(token);
        if (user == null)
            return Unauthorized();

        var response = await feedbackService.SubmitClientEventData(feedbackDTO, user);
        return Ok(response);
    }
}
