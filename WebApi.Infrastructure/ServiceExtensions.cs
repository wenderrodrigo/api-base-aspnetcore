using Microsoft.Extensions.DependencyInjection;
using WebApiServicos.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.Interfaces.Repositories;
using WebApi.Infrastructure.Repositories;
using WebApi.Application.Interfaces;
using WebApi.Application.services;
using FluentValidation;
using WebApi.Application.DTOs;
using WebApi.Application.Validations;

namespace WebApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MySqlConnection");

        services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IItemRepository, ItemRepository>();

        return services;
    }

    public static IServiceCollection AddTransient(this IServiceCollection services)
    {
        services.AddTransient<IItemServices, ItemServices>();
        services.AddTransient<IValidator<ItemDTO>, ItemDTOValidator>();

        return services;
    }

}
