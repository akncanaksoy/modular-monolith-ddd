using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Octovis.User.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddUserApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assm));

            return services;
        }
    }
}
