using Microsoft.Extensions.DependencyInjection;
using WebApiServicos.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {

        string? sqlServerConnection = configuration.GetConnectionString("SqlServerConnection");
        services.AddDbContext<SqlServerDbContext>(
            options => options.UseSqlServer(sqlServerConnection)
        );

        return services;
    }
}
