using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using PocketDDD.Server.Model.DBModel;
using PocketDDD.Server.Services;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;

namespace PocketDDD.Server.WebAPI.Authentication;

public class UserIsRegisteredOptions : AuthenticationSchemeOptions { }
public class UserIsRegisteredAuthHandler : AuthenticationHandler<UserIsRegisteredOptions>
{
    public const string SchemeName = "UserIsRegisteredScheme";

    private readonly UserService userService;

    public UserIsRegisteredAuthHandler(IOptionsMonitor<UserIsRegisteredOptions> options, ILoggerFactory loggerFactory, UrlEncoder urlEncoder, ISystemClock clock, UserService userService) : base(options, loggerFactory, urlEncoder, clock)
    {
        this.userService = userService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        string token = Request.Headers["Authorization"];
        var user = await userService.FetchUserByToken(token);
        if (user is null)
            return AuthenticateResult.Fail("Invalid authorization token");

        var userIdentity = (new GenericIdentity(user.Name));
        userIdentity.AddClaim(new Claim(User.UserIdClaim, user.Id.ToString()));
        var userPricipal = new GenericPrincipal(userIdentity, null);
        var ticket = new AuthenticationTicket(userPricipal, UserIsRegisteredAuthHandler.SchemeName);

        return AuthenticateResult.Success(ticket);
    }
}
