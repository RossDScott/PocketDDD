using Fluxor;

namespace PocketDDD.BlazorClient.Features.Login.Store;

public static class LoginReducer
{
    [ReducerMethod]
    public static LoginState OnLogin(LoginState state, LoginAction action) =>
        state with { IsLoggingIn = true };

    [ReducerMethod]
    public static LoginState OnLoginSuccess(LoginState state, SetLoginSuccess action) => 
        state with { IsLoggingIn = false };

    [ReducerMethod]
    public static LoginState OnLoginFailed(LoginState state, SetLoginFailed action) =>
        state with { IsLoggingIn = false, LoginFailed = true };
}
