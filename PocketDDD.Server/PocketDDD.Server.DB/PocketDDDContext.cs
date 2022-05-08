using Microsoft.EntityFrameworkCore;
using PocketDDD.Server.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketDDD.Server.DB;

public class PocketDDDContext : DbContext
{
    public PocketDDDContext(DbContextOptions<PocketDDDContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<EventDetail> EventDetail { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }
    public DbSet<Session> Sessions { get; set; }

    public DbSet<UserEventFeedback> UserEventFeedback { get; set; }
    public DbSet<UserSessionFeedback> UserSessionFeedback { get; set; }
}



