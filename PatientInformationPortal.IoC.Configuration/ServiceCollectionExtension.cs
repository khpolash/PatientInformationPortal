using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientInformationPortal.Application;
using PatientInformationPortal.Infrastructure;
using PatientInformationPortal.SharedKernel.Core;

namespace PatientInformationPortal.IoC.Configuration;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ServiceRegistation(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddControllersWithViews();
        // Add services to the container.
        services.AddRazorPages();
        services.InfrastructureServices(configuration);
        services.ApplicationServices(configuration);
        services.AddAuthorization();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddControllers().AddNewtonsoftJson();
        services.AddSwaggerGen();

        var origins = configuration.GetSection("Domain").Get<Domain>();
        if (origins.ClientTwo.Count != 0) { origins?.ClientOne?.AddRange(origins.ClientTwo); }

        services.AddCors(options => options.AddPolicy("WebAppCorsPolicy", builder =>
        {
            builder.WithOrigins([.. origins.ClientOne]).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        }));


        return services;
    }
}
