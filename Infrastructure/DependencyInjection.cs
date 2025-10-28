using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; // Bạn có thể cần using này
using Core.Interfaces;
using Core.Options;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        // THAY ĐỔI 1: Thêm tham số "string connectionString"
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, string connectionString)
        {
            // THAY ĐỔI 2: Dùng trực tiếp "connectionString"
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            
            // XÓA PHIÊN BẢN CŨ NÀY
            // services.AddDbContext<AppDbContext>((provider, options) =>
            // {
            //     var connection = provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection;
            //     options.UseSqlServer(connection);
            // });

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IExternalVendorRepository, ExternalVendorRepository>();
            services.AddHttpClient<IJokeHttpClientService, JokeHttpClientService>(client =>
            {
                client.BaseAddress = new Uri("https://official-joke-api.appspot.com/"); 
            });
            services.AddHttpClient<ICoindeskHttpClientService, CoindeskHttpClientService>(client =>
            {
                client.BaseAddress = new Uri("https://api.coindesk.com/v1/"); 
            });
            return services;
        }
    }
}