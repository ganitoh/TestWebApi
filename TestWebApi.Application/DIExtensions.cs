using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TestWebApi.Application.CQRS;
using TestWebApi.Application.CQRS.FriendShips.Commands.CreateFirenedShip;
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

            services.AddScoped<IValidator<UserCreateCommand>, UserCreateCommandValidation>();
            services.AddScoped<IValidator<CreateFriendShipCommand>, CreaeteFrindShipCommandValidator>();
            services.AddScoped<IValidator<PictureCreateCommand>, PictureCreateCommandValidtor>();
            return services;
        }

        public static IServiceCollection AddCQRS(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(
                    typeof(PictureCreateCommand).Assembly,
                    typeof(PictureCreateCommandHandler).Assembly,
                    typeof(UserCreateCommand).Assembly,
                    typeof(UserCreateCommandHandler).Assembly,
                    typeof(UserDeleteCommand).Assembly,
                    typeof(UserDeleteCommandHandler).Assembly);

                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            return services;
        }
    }
}
