using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Features.Session.Store;

public record ViewSessionAction(int SessionId);
public record SetSessionAction(
    PocketDDD.Shared.API.ResponseDTOs.Session Session,
    PocketDDD.Shared.API.ResponseDTOs.Track Track,
    PocketDDD.Shared.API.ResponseDTOs.TimeSlot TimeSlot,
    bool IsBookmarked);
public record ToggleBookmarkedAction(int SessionId, bool Bookmarked);
