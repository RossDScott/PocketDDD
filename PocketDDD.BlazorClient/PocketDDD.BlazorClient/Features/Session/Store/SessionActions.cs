using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Features.Session.Store;

public record ViewSessionAction(int SessionId);
public record SetSessionAction(
    PocketDDD.Shared.API.ResponseDTOs.SessionDTO Session,
    PocketDDD.Shared.API.ResponseDTOs.TrackDTO Track,
    PocketDDD.Shared.API.ResponseDTOs.TimeSlotDTO TimeSlot,
    bool IsBookmarked);
public record ToggleBookmarkedAction(int SessionId, bool Bookmarked);
