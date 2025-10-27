using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Core.Interfaces;
using Core.Options;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                var connection = provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection;
                options.UseSqlServer(connection);
            });

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IExternalVendorRepository, ExternalVendorRepository>();
            services.AddHttpClient<IJokeHttpClientService, JokeHttpClientService>(client =>
            {
                // Cấu hình BaseAddress và các header mặc định ở đây
                client.BaseAddress = new Uri("https://official-joke-api.appspot.com/"); // Ví dụ URL
            });
            services.AddHttpClient<ICoindeskHttpClientService, CoindeskHttpClientService>(client =>
            {
                client.BaseAddress = new Uri("https://api.coindesk.com/v1/"); // Ví dụ URL
            });
            return services;
        }
    }
}
