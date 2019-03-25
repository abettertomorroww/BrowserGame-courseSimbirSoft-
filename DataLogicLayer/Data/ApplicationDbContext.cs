using DataLogicLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace DataLogicLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserData>
    {
        public DbSet<CharacterData> Characters { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionBuilder.UseNpgsql(@"User ID = postgres; Password = 1234; Server=localhost;
                    Port=5432;Database=GameDB;Integrated Security=true;Pooling = true;", b => b.MigrationsAssembly("DataLogicLayer"));
                return new ApplicationDbContext(optionBuilder.Options);
            }
        }

    }
}
