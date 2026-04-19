using AirelineBookingSystem.Notifications.Core.Repositories;
using AirelineBookingSystem.Notifications.Infrastructure.Repositories;
using AirelineBookingSystem.Notifications.Application.Handlers;

using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using AirelineBookingSystem.Notifications.Application.Interfaces;
using AirelineBookingSystem.Notifications.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.it

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MediatR
var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(SendNotificationHandler).Assembly
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

// Application services
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

// Add sql connection to the services
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
