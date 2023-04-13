using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Features.Security.Store;

public record CheckUserAction();
public record LoginAction(string LoginName);

public record SetLoginSuccess(LoginResult User);
public record SetLoginFailed();