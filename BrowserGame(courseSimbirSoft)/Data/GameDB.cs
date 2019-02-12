using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrowserGame_courseSimbirSoft_.Models;

namespace BrowserGame_courseSimbirSoft_.Data
{
    public class GameDB : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Door> Doors { get; set; }
        public GameDB(DbContextOptions<GameDB> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // disable cascade delete
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
