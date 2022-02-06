using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using VineBasementApp.Persistance.DataAccess;
using VineBasementApp.Persistance.Repositories.Generic;
using VineBasementHelpers.Interfaces;

namespace VineBasementApp.Persistance.DependencyInjection
{
    public static class DI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VineBasementContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))/*.EnableSensitiveDataLogging()*/);
            services.AddScoped<IVineBasementContext>(provider => provider.GetService<VineBasementContext>());

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            services.AddServicesWithAttributeOfType<TransientServiceAttribute>();

            return services;
        }
    }
}
