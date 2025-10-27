using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Options;

namespace Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<ConnectionStringOptions>(
                configuration.GetSection(ConnectionStringOptions.SectionName)
            );

            return services;
        }
    }
}
