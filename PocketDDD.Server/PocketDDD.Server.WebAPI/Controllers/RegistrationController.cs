using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketDDD.Server.Model.DTOs;
using PocketDDD.Server.Services;

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
    public Task<RegisterResponseDTO> Login(RegisterDTO dto)
    {
        return registrationService.Register(dto);
    }
}
