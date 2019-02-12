using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BrowserGame_courseSimbirSoft_.Models;

namespace BrowserGame_courseSimbirSoft_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Character> Characters { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Character>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
