using Fluxor;
using Microsoft.AspNetCore.Components;
using PocketDDD.BlazorClient.Features.HeaderBar.Store;
using PocketDDD.BlazorClient.Features.Home.Store;
using PocketDDD.BlazorClient.Services;

namespace PocketDDD.BlazorClient.Features.Session.Store;

public class SessionEffects
{
    private readonly IState<SessionState> _state;
    private readonly LocalStorageContext _localStorage;
    private readonly IPocketDDDApiService _pocketDDDAPI;
    private readonly NavigationManager _navigation;

    public SessionEffects(IState<SessionState> state, LocalStorageContext localStorage, IPocketDDDApiService pocketDDDAPI, NavigationManager navigation)
    {
        _state = state;
        _localStorage = localStorage;
        _pocketDDDAPI = pocketDDDAPI;
        _navigation = navigation;
    }

    [EffectMethod]
    public async Task OnViewSession(ViewSessionAction action, IDispatcher dispatcher)
    {
        var eventData = await _localStorage.EventData.GetAsync();
        if (eventData is null)
            return;

        var bookmarks = await _localStorage.SessionBookmarks.GetOrDefaultAsync();

        var session = eventData.Sessions.Single(x => x.Id == action.SessionId);
        var track = eventData.Tracks.Single(x => x.Id == session.TrackId);
        var timeSlot = eventData.TimeSlots.Single(x => x.Id == session.TimeSlotId);
        var isBookmarked = bookmarks.Contains(session.Id);
        var title = session.Speaker;

        dispatcher.Dispatch(new SetHeaderBarTitleAction(title));
        dispatcher.Dispatch(new SetBackButtonVisabilityAction(true));
        dispatcher.Dispatch(new SetSessionAction(session, track, timeSlot, isBookmarked));
        _navigation.NavigateTo($"session/{action.SessionId}");
    }

    [EffectMethod]
    public async Task OnToggleSessionBookmarked(ToggleBookmarkedAction action, IDispatcher dispatcher)
    {
        var bookmarks = await _localStorage.SessionBookmarks.GetOrDefaultAsync();

        if (action.Bookmarked && !bookmarks.Contains(action.SessionId))
            bookmarks.Add(action.SessionId);
        else if(!action.Bookmarked && bookmarks.Contains(action.SessionId))
            bookmarks.Remove(action.SessionId);

        await _localStorage.SessionBookmarks.SetAsync(bookmarks);
    }
}