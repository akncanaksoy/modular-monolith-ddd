
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Octovis.API.Middlewares;
using Octovis.Location.Application;
using Octovis.Location.Infrastructure;
using Octovis.User.Application;
using Octovis.User.Infrastructure;

namespace Octovis.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            ServiceRegistration(builder);
            builder.Services.AddHttpContextAccessor();


            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }


        public static void ServiceRegistration(WebApplicationBuilder builder)
        {
            // Register application and infrastructure services


            builder.Services.AddUserApplicationRegistration();
            builder.Services.AddUserInfrastructureRegistration(builder.Configuration);

            builder.Services.AddLocationApplicationRegistration();
            builder.Services.AddLocationInfrastructureRegistration(builder.Configuration);

        }
    }


}
