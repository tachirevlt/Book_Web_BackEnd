using Application;
using Infrastructure;
using Core;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký các tầng
builder.Services.AddCore(builder.Configuration); 
builder.Services.AddApplicationDI();
// Đọc chuỗi kết nối trực tiếp từ builder
var connectionString = builder.Configuration.GetSection("ConnectionStringOptions:DefaultConnection").Value;

// Truyền chuỗi kết nối vào
builder.Services.AddInfrastructureDI(connectionString);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();





// using Application;
// using Infrastructure;
// using Core;

// namespace Api
// {
//     public static class DependencyInjection
//     {
//         public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
//         {
//             services.AddApplicationDI()
//                     .AddInfrastructureDI()
//                     .AddCore(configuration);

//             return services;
//         }
//     }
// }
