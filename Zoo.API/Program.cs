using Application.Interfaces; 
using Application.Services;
using Infrastructure.Repositories;
using Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPresentation();
builder.Services.AddControllers(); // <-- Обязательно!
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // <-- Для Swagger

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers(); // <-- Обязательно!

app.Run();



public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAnimalTransferService, AnimalTransferService>();
        services.AddScoped<IFeedingOrganizationService, FeedingOrganizationService>();
        services.AddScoped<IZooStatisticsService, ZooStatisticsService>();

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IAnimalRepository, InMemoryAnimalRepository>();
        services.AddSingleton<IEnclosureRepository, InMemoryEnclosureRepository>();
        services.AddSingleton<IFeedingScheduleRepository, InMemoryFeedingScheduleRepository>();

        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }
}
