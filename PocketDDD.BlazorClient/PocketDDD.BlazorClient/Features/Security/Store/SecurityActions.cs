using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Features.Security.Store;

public record CheckUserAction();
public record LoginAction(string LoginName);

public record SetLoginSuccessAction(LoginResult User);
public record SetCurrentUserAction(LoginResult User);
public record SetLoginFailed();