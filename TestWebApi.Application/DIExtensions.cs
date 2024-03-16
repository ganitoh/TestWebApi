using Microsoft.Extensions.DependencyInjection;
using System;using TestWebApi.Application.Services.Abstarction;
using TestWebApi.Application.Services.Implementation;

namespace TestWebApi.Application
{
    public static class DIExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IHashPassword, HashPassrod>();
            services.AddTransient<IPictureService, PictureService>();
            return services;
        }
    }
}
