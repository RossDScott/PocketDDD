using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Features.Security.Store;

public record CheckUserAction();
public record LoginAction(string LoginName);

public record SetLoginSuccessAction(LoginResultDTO User);
public record SetCurrentUserAction(LoginResultDTO User);
public record SetLoginFailed();
public record DeleteAllDataAndLogOutAction();