

using Dominio.Interfaces;
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
}