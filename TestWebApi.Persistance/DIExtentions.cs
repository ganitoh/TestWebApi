using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.DependencyInjection;

using TestWebApi.Persistance.Services.Repository.Abstraction;
using TestWebApi.Persistance.Services.Repository.Implementation;

namespace TestWebApi.Persistance
{
    public static class DIExtentions
    {
        public static IServiceCollection AddRepository(
            this IServiceCollection services, 
            DbContextOptions<ApplicationContext> options)
        {

            var context = new ApplicationContext(options);

            var constructorUserRepo = typeof(UserRepository).GetConstructor(new []{typeof(ApplicationContext)});
            if (constructorUserRepo == null)
                throw new ArgumentNullException(nameof(constructorUserRepo));

            var constructorPictureRepo = typeof(PictureRepository).GetConstructor(new[] {typeof(ApplicationContext)});
            if (constructorPictureRepo == null)
                throw new ArgumentNullException(nameof(constructorPictureRepo));

            var constructorFriendShipRepo = typeof(FriendShipRepository).GetConstructor(new[] { typeof(ApplicationContext)});
            if (constructorFriendShipRepo == null)
                throw new ArgumentNullException(nameof(constructorFriendShipRepo));

            services.AddTransient<IUserRepository, UserRepository>(provider => 
                (UserRepository)constructorUserRepo.Invoke(new[] { context }));

            services.AddTransient<IPictureRepository, PictureRepository>(provider =>
                (PictureRepository)constructorPictureRepo.Invoke(new[] { context }));

            services.AddTransient<IFriendShipRepository,FriendShipRepository>(provider =>
            (FriendShipRepository)constructorFriendShipRepo.Invoke(new[] { context }));

            return services;
        }

        public static IServiceCollection AddMSSQL(this IServiceCollection services, string connectionStirng)
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(connectionStirng).Options;
            services.AddRepository(options);

            return services;
        }
    }
}
