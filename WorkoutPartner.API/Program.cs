using WorkoutPartner.API.Endpoints;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Infrastructure.Configuration;
using Environment = WorkoutPartner.Domain.Configuration.Environment;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment.IsProduction()
    ? Environment.Production
    : Environment.Development;

builder.Services.ConfigureServices(builder.Configuration, environment);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();

app.Run();
