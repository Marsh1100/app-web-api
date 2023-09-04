

using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Persistencia.UnitOfWork;

namespace API.Extensions;

//Carpeta Extensiones / AplicationServiceExtension.cs
public static class AplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()  //Withorigin (https://domini.com)
        .AllowAnyMethod()          //WithMethods ('GET', 'POST')
        .AllowAnyHeader());
    });

    public static void AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1,0);
            options.AssumeDefaultVersionWhenUnspecified = true; 
            options.ApiVersionReader = new QueryStringApiVersionReader("ver");
        });
    }
}