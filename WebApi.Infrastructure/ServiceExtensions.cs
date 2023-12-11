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
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MySqlConnection");

        services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        //General
        services.AddScoped<ICondominiumRepository, CondominiumRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserCondominiumRepository, UserCondominiumRepository>();

        //Adverts
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IItemImageRepository, ItemImageRepository>();

        //Condominium communication
        services.AddScoped<ICondominiumNotificationRepository, CondominiumNotificationRepository>();

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

        //General
        services.AddTransient<ICondominiumServices, CondominiumServices>();
        services.AddTransient<IUserServices, UserServices>();
        services.AddTransient<IUserCondominiumServices, UserCondominiumServices>();

        //Adverts
        services.AddTransient<ICategoryServices, CategoryServices>();
        services.AddTransient<IItemServices, ItemServices>();
        services.AddTransient<IItemImageServices, ItemImageServices>();

        //Condominium communication
        services.AddTransient<ICondominiumNotificationServices, CondominiumNotificationServices>();


        //General
        services.AddTransient<IValidator<CondominiumDTO>, CondominiumDTOValidator>();
        services.AddTransient<IValidator<UserDTO>, UserDTOValidator>();
        services.AddTransient<IValidator<UserCondominiumDTO>, UserCondominiumDTOValidator>();

        //Adverts
        services.AddTransient<IValidator<CategoryDTO>, CategoryDTOValidator>();
        services.AddTransient<IValidator<ItemDTO>, ItemDTOValidator>();
        services.AddTransient<IValidator<ItemImageDTO>, ItemImageDTOValidator>();

        //Condominium communication
        services.AddTransient<IValidator<CondominiumNotificationDTO>, CondominiumNotificationDTOValidator>();

        return services;
    }

}
