using Microsoft.EntityFrameworkCore;
using PocketDDD.Server.DB;
using PocketDDD.Server.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocketDDD.Shared.API.RequestDTOs;
using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.Server.Services;
public class EventDataService
{
    private readonly PocketDDDContext dbContext;

    public EventDataService(PocketDDDContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<EventDataResponseDTO?> FetchLatestEventData(EventDataUpdateRequestDTO requestDTO)
    {
        var eventDetails = await dbContext.EventDetail
                                          .Include(x => x.TimeSlots)
                                          .Include(x => x.Tracks)
                                          .Include(x => x.Sessions)
                                          .SingleAsync(x => x.Id == 1);
            
        if (requestDTO.Version == eventDetails!.Version)
            return null;

        var dtoResponse = new EventDataResponseDTO
        {
            Version = eventDetails.Version,
            TimeSlots = eventDetails.TimeSlots.Select(ts => new TimeSlotDTO
            {
                Id = ts.Id,
                Info = ts.Info,
                From = ts.From,
                To = ts.To
            }).ToList(),
            Tracks = eventDetails.Tracks.Select(t => new TrackDTO
            {
                Id = t.Id,
                Name = t.Name,
                RoomName = t.RoomName
            }).ToList(),
            Sessions = eventDetails.Sessions.Select(s => new SessionDTO
            {
                Id = s.Id,
                Title = s.Title,
                ShortDescription = s.ShortDescription,
                FullDescription = s.FullDescription,
                Speaker = s.Speaker,
                TimeSlotId = s.TimeSlot.Id,
                TrackId = s.Track.Id
            }).ToList()
        };

        return dtoResponse;
    }
}
