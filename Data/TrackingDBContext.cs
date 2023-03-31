using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TrackingAppReact.Models;

namespace TrackingAppReact.Data
{
    public class TrackingDBContext : DbContext
    {

        // configure context for in-memory db

        public TrackingDBContext(DbContextOptions<TrackingDBContext> options) : base(options)
        {        
        }


        // results from the database 
        public DbSet<Inbox> Inbox { get; set; }
        public DbSet<OrderChange> OrderChange { get; set; }
    }
}
