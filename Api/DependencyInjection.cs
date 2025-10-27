using Application;
using Infrastructure;
using Core;

namespace Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                    .AddInfrastructureDI()
                    .AddCore(configuration);

            return services;
        }
    }
}
