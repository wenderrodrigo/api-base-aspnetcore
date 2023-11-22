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
using AutoMapper;
using WebApi.Infrastructure.Database.Configuration;

namespace WebApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MySqlConnection");

        services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICondominiumRepository, CondominiumRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserCondominiumRepository, UserCondominiumRepository>();


        // Adicione a configuração do AutoMapper
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            // Aqui você pode configurar seus perfis de mapeamento
            cfg.AddProfile<MappingProfiles>();
            // Adicione mais perfis, se necessário
        });

        services.AddSingleton<IMapper>(mapperConfig.CreateMapper());

        return services;
    }

    public static IServiceCollection AddTransient(this IServiceCollection services)
    {
        services.AddTransient<IItemServices, ItemServices>();
        services.AddTransient<ICategoryServices, CategoryServices>();
        services.AddTransient<ICondominiumServices, CondominiumServices>();
        services.AddTransient<IUserServices, UserServices>();
        services.AddTransient<IUserCondominiumServices, UserCondominiumServices>();
        services.AddTransient<IValidator<ItemDTO>, ItemDTOValidator>();
        services.AddTransient<IValidator<CategoryDTO>, CategoryDTOValidator>();
        services.AddTransient<IValidator<CondominiumDTO>, CondominiumDTOValidator>();
        services.AddTransient<IValidator<UserDTO>, UserDTOValidator>();
        services.AddTransient<IValidator<UserCondominiumDTO>, UserCondominiumDTOValidator>();
        //services.AddTransient<IValidator<UserCondominiumDTO>, UserCondominiumDTOValidator>();

        return services;
    }

}
