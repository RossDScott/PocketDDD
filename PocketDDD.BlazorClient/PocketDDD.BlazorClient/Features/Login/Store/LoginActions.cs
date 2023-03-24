using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Features.Login.Store;

public record LoginAction(string LoginName);

public record SetLoginSuccess(LoginResult Result);
public record SetLoginFailed();