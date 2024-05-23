using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PatientInformationPortal.Infrastructure.Persistence;

namespace PatientInformationPortal.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection InfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<PatientInformationPortalDbContext>((serviceProvider, builder) =>
        {
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            builder.UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>());
            builder.LogTo(Console.WriteLine, LogLevel.Debug);
        }, ServiceLifetime.Scoped);

        services.AddHttpContextAccessor();

        return services;

    }
}
