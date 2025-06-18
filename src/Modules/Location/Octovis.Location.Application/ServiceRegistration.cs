using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Octovis.Location.Application.Validations;
using System.Reflection;
using Octovis.Location.Application.Interfaces.Services;


namespace Octovis.Location.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddLocationApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assm));

            services.AddValidatorsFromAssemblyContaining<CreateLocationCommandValidator>();



            return services;
        }
    }
}
