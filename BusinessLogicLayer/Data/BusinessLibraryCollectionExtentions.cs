using BusinessLogicLayer.Services.Implementation;
using BusinessLogicLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using DataLogicLayer.Services.Implementation;

namespace BusinessLogicLayer.Data

{
    public static class BusinessLibraryCollectionExtentions
    {
        public static IServiceCollection AddBusinessLibraryCollection(this IServiceCollection services)
        {
            services.AddScoped<ICharacterBusinessService, CharacterBusinessService>();
            services.AddScoped<IUserBusinessService, UserBusinessService>();
            return services;
        }
    }
}
