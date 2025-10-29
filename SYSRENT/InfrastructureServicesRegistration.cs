using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SYSRENT.Application.Contract;
using SYSRENT.Application.Data;
using SYSRENT.Infrastructure.Context;
using SYSRENT.Infrastructure.Repository;

namespace SYSRENT.Infrastructure;

public static class InfrastructureServicesRegistration
{

    public static IServiceCollection AddServicesInfrasttructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISqlDbConnection, SqlDapperConnection>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IHorarioRepository, HorarioRepository>();
        services.AddScoped<IVehiculoRepository, VehiculoRepository>();

        return services;
    }



}
