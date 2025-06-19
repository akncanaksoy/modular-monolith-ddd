using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Octovis.Location.Application.Interfaces.Repositories;
using Octovis.Location.Application.Interfaces.Services;
using Octovis.Location.Infrastructure.EventBus;
using Octovis.Location.Infrastructure.Persistence.Context;
using Octovis.Location.Infrastructure.Persistence.Repositories;
using Octovis.Location.Infrastructure.Services;
using Octovis.SharedKernel.Domain;
using System.Reflection;


namespace Octovis.Location.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddNotificationInfrastructureRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddScoped<IUnitOfWork, Ef_UnitOfWork>();
            services.AddScoped<ILocationRepository, Ef_LocationRepository>();
            services.AddScoped<IAddressRepository, Ef_AddressRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();

            services.AddScoped<IIntegrationEventPublisher, IntegrationEventPublisher>();

            services.AddDbContext<LocationDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            
            services.AddScoped<IUserContext, HttpUserContext>();


            return services;
        }


    }
}
