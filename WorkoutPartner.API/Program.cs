using Microsoft.OpenApi.Models;
using WorkoutPartner.API.Endpoints;
using WorkoutPartner.Infrastructure.Configuration;
using Environment = WorkoutPartner.Domain.Configuration.Environment;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment.IsProduction()
    ? Environment.Production
    : Environment.Development;

builder.Services.ConfigureServices(builder.Configuration, environment);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();

app.Run();
