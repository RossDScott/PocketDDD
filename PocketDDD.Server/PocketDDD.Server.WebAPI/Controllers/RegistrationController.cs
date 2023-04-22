using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketDDD.Server.Model.DTOs;
using PocketDDD.Server.Services;
using PocketDDD.Shared.API.RequestDTOs;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.Server.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly RegistrationService registrationService;

    public RegistrationController(RegistrationService registrationService)
    {
        this.registrationService = registrationService;
    }

    [HttpPost("[Action]")]
    public Task<LoginResultDTO> Login(RegisterDTO dto)
    {
        return registrationService.Register(dto);
    }
}
