using PocketDDD.BlazorClient.Features.Sync.Store;
using PocketDDD.Shared.API.ResponseDTOs;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace PocketDDD.BlazorClient.Features.Home.Store;

public static class EventDataMapper
{
    public static IImmutableList<TimeSlot> ToHomeStateModel(this EventDataResponse eventData) =>
        eventData.TimeSlots.Select(ts => new TimeSlot
        {
            Id = ts.Id,
            From = ts.From,
            To = ts.To,
            Info = ts.Info,
            Sessions = eventData.Sessions
                                .Where(s => s.TimeSlotId == ts.Id)
                                .Select(s => new Session
                                {
                                    Id = s.Id,
                                    SpeakerName = s.Speaker,
                                    Title = s.Title,
                                    TrackName = eventData.Tracks.Single(tr => tr.Id == s.TrackId).Name,
                                    RoomName = eventData.Tracks.Single(tr => tr.Id == s.TrackId).RoomName
                                }).ToImmutableList()
        }).ToImmutableList();
}
