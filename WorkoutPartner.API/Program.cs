using WorkoutPartner.API.Endpoints;
using WorkoutPartner.Infrastructure.Configuration;
using Environment = WorkoutPartner.Domain.Configuration.Environment;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment.IsProduction()
    ? Environment.Production
    : Environment.Development;

builder.Services.ConfigureServices(builder.Configuration, environment);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();

app.Run();
