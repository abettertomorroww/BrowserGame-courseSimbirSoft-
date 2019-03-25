using DataLogicLayer.Services;
using DataLogicLayer.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DataLogicLayer.Data
{
    public static class DataLibraryCollectionExtentions
    {
        public static IServiceCollection AddDataLibraryCollection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICharacterDataService, CharacterDataService>();
            return services;
        }
    }
}
