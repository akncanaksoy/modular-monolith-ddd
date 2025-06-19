using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Octovis.Notification.Application.Interfaces.Repositories;
using Octovis.Notification.Infrastructure.Persistence.Context;
using Octovis.Notification.Infrastructure.Persistence.Repositories;
using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddLocationInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddScoped<IUnitOfWork, Ef_UnitOfWork>();
            services.AddScoped<INotificationRequestRepository, Ef_NotificationRequestRepository>();


            services.AddDbContext<NotificationDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


            return services;
        }


    }
}
