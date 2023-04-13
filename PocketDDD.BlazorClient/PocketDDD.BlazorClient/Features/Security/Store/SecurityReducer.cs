using Fluxor;

namespace PocketDDD.BlazorClient.Features.Security.Store;

public static class SecurityReducer
{
    [ReducerMethod]
    public static SecurityState OnLogin(SecurityState state, LoginAction action) =>
        state with { IsLoggingIn = true };

    [ReducerMethod]
    public static SecurityState OnLoginSuccess(SecurityState state, SetLoginSuccess action) =>
        state with { IsLoggingIn = false, CurrentUser = action.User };

    [ReducerMethod]
    public static SecurityState OnLoginFailed(SecurityState state, SetLoginFailed action) =>
        state with { IsLoggingIn = false, LoginFailed = true };
}
