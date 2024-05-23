using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientInformationPortal.Application.Repositories.Base;

namespace PatientInformationPortal.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.Scan(scan => scan.FromAssemblyOf<IApplication>()
        .AddClasses(classes => classes.AssignableTo<IApplication>())
        .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepository<>)))
        .AsSelfWithInterfaces()
        .WithScopedLifetime());

        services.AddAutoMapper(x => x.AddMaps(typeof(IApplication).Assembly));

        return services;
    }
}
