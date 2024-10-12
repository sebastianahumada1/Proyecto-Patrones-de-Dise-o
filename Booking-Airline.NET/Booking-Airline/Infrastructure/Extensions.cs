using Booking_Airline.Application.Services;
using Booking_Airline.Application.Services.Interfaces;
using Booking_Airline.Common.Providers;
using Booking_Airline.Infrastructure.Repositories;
using Booking_Airline.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Booking_Airline.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext")));

        services.AddTransient<DbContext, ApplicationDbContext>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<IPassengerRepository, PassengerRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddSingleton<IPasswordHasherService, BcryptHasherService>();

        return services;
    }

    public static IServiceCollection AddStrategy(this IServiceCollection services)
    {
        services.AddTransient<IFlightClassCategoryService, FlightClassCategoryService>();

        return services;
    }
}
