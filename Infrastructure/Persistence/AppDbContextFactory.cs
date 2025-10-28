using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Persistence
{
    // Lớp này CHỈ dùng cho lệnh "dotnet ef"
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            string apiProjectPath = Directory.GetCurrentDirectory();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(apiProjectPath) 
                .AddJsonFile("appsettings.json") 
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            // Lấy chuỗi kết nối
            var connectionString = configuration.GetSection("ConnectionStringOptions:DefaultConnection").Value;

            // Tạo DbContext
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}