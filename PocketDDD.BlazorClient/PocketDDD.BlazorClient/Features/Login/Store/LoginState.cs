using Fluxor;

namespace PocketDDD.BlazorClient.Features.Login.Store;

[FeatureState]
public record LoginState
{
    public string LoginName { get; init; } = "";
    public bool IsLoggingIn { get; init; } = false;
    public bool LoginFailed { get; init; } = false;
}