using Application;
using Infrastructure;
using Core;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký các tầng
builder.Services.AddCore(builder.Configuration); 
builder.Services.AddApplicationDI();
builder.Services.AddInfrastructureDI();

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
