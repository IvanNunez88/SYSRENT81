using Microsoft.Extensions.DependencyInjection;

namespace SYSRENT.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddServicesApplication(this IServiceCollection services)
    {
        //CONFIGURAR MEDIATR
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ApplicationServicesRegistration).Assembly));

        return services;
    }
}
