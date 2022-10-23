using Moviy.Business.Interfaces;
using Moviy.Business.Interfaces.Services;
using Moviy.Business.Notifications;
using Moviy.Business.Services;
using Moviy.Data.Context;
using Moviy.Data.Repository;

namespace Moviy.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MoviyDbContext>();
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ILineRouteRepository, LineRouteRepository>();
            services.AddScoped<ITravelRepository, TravelRepository>();
            services.AddScoped<ILocalRepository, LocalRepository>();

            services.AddScoped<INotificator, Notificator>();


            services.AddScoped<IBusService, BusService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<ILineRouteService, LineRouteService>();
            services.AddScoped<ITravelService, TravelService>();
            services.AddScoped<ILocalService, LocalService>();


            return services;
        }
    }

}
