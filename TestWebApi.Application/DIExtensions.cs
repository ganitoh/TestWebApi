using Microsoft.Extensions.DependencyInjection;
using System;
using TestWebApi.Application.CQRS.Pictures.Commands.PictureCreate;
using TestWebApi.Application.CQRS.Users.Commands.UserCreate;
using TestWebApi.Application.CQRS.Users.Commands.UserDelete;
using TestWebApi.Application.Services.Abstarction;
using TestWebApi.Application.Services.Implementation;

namespace TestWebApi.Application
{
    public static class DIExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHashPassword, HashPassrod>();
            services.AddScoped<IPictureService, PictureService>();
            return services;
        }

        public static IServiceCollection AddCQRS(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblies(
                    typeof(PictureCreateCommand).Assembly,
                    typeof(PictureCreateCommandHandler).Assembly,
                    typeof(UserCreateCommand).Assembly, 
                    typeof(UserCreateCommandHandler).Assembly,
                    typeof(UserDeleteCommand).Assembly,
                    typeof(UserDeleteCommandHandler).Assembly));

            return services;
        }
    }
}
