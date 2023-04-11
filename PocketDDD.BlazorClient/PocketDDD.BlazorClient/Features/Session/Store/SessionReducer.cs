using Fluxor;
using System.Runtime.InteropServices;

namespace PocketDDD.BlazorClient.Features.Session.Store;

public static class SessionReducer
{
    [ReducerMethod]
    public static SessionState OnSetSession(SessionState state, SetSessionAction action) =>
        state with
        {
            Session = new Session
            {
                Id = action.Session.Id,
                Title = action.Session.Title,
                Detail = action.Session.FullDescription,
                SpeakerName = action.Session.Speaker,

                From = action.TimeSlot.From,
                To = action.TimeSlot.To,

                TrackName = action.Track.Name,
                RoomName = action.Track.RoomName,
                
                IsBookmarked = action.IsBookmarked
            }
        };

    [ReducerMethod]
    public static SessionState OnToggleSessionBookmarked(SessionState state, ToggleBookmarkedAction action) =>
        state with 
        { 
            Session = state.Session! with { IsBookmarked = action.Bookmarked } 
        };
}
