using Fluxor;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Features.Security.Store;

[FeatureState]
public record SecurityState
{
    public LoginResult? CurrentUser { get; init; } = null;

    public bool IsLoggingIn { get; init; } = false;
    public bool LoginFailed { get; init; } = false;
}