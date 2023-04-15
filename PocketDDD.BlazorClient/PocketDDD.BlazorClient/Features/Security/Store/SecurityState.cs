using Fluxor;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Features.Security.Store;

[FeatureState]
public record SecurityState
{
    public LoginResultDTO? CurrentUser { get; init; } = null;

    public bool IsLoggingIn { get; init; } = false;
    public bool LoginFailed { get; init; } = false;
}