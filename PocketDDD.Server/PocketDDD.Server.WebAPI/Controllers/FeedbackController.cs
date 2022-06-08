using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketDDD.Server.Model.DTOs;
using PocketDDD.Server.Services;
using PocketDDD.Server.WebAPI.Authentication;

namespace PocketDDD.Server.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = UserIsRegisteredAuthHandler.SchemeName)]
public class FeedbackController : ControllerBase
{
    private readonly UserService userService;
    private readonly FeedbackService feedbackService;

    public FeedbackController(UserService userService, FeedbackService feedbackService)
    {
        this.userService = userService;
        this.feedbackService = feedbackService;
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> ClientSessionFeedback(SessionFeedbackDTO feedbackDTO)
    {
        var response = await feedbackService.SubmitClientSessionFeedback(feedbackDTO, CurrentUserId);
        return Ok(response);
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> ClientEventFeedback(EventFeedbackDTO feedbackDTO)
    {
        var response = await feedbackService.SubmitClientEventFeedback(feedbackDTO, CurrentUserId);
        return Ok(response);
    }

    private int CurrentUserId => int.Parse(User.Claims.Single(x => x.Type == PocketDDD.Server.Model.DBModel.User.UserIdClaim).Value);
}
