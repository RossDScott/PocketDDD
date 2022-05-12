using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketDDD.Server.Model.DTOs;
using PocketDDD.Server.Services;

namespace PocketDDD.Server.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FeedbackServiceController : ControllerBase
{
    private readonly UserService userService;
    private readonly FeedbackService feedbackService;

    public FeedbackServiceController(UserService userService, FeedbackService feedbackService)
    {
        this.userService = userService;
        this.feedbackService = feedbackService;
    }

    [HttpPost]
    public async Task<FeedbackResponseDTO?> ClientSessionFeedback(SessionFeedbackDTO feedbackDTO)
    {
        string token = Request.Headers["Authorization"];
        var user = await userService.FetchUserByToken(token);
        if (user == null)
            return null;

        return await feedbackService.SubmitClientSessionFeedback(feedbackDTO, user);
    }

    public async Task<FeedbackResponseDTO?> SubmitClientEventData(EventFeedbackDTO feedbackDTO)
    {
        string token = Request.Headers["Authorization"];
        var user = await userService.FetchUserByToken(token);
        if (user == null)
            return null;

        return await feedbackService.SubmitClientEventData(feedbackDTO, user);
    }
}
