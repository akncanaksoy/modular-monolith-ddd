using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Octovis.User.Application.Interfaces.Repositories;
using Octovis.User.Infrastructure.Persistence.Context;
using Octovis.User.Infrastructure.Persistence.Repositories;
using System.Reflection;

namespace Octovis.User.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddUserInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddScoped<IUserRepository, Ef_UserRepository>();

            services.AddDbContext<UserDbContext>(options =>
             options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
