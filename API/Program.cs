/*"ConnectionStrings": {
    "DefaultConnection":"server=localhost;user=root;password= ;database =AutoRepairDBmb"
  }*/ //Casita

/*"ConnectionStrings": {
    "DefaultConnection":"server=localhost;user=root;password=123456 ;database =AutoRepairDBmb"
  }*/ //campus

using System.Reflection;
using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors(); //Extensiones
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());//automapper
// Add services to the container.
builder.Services.AddAplicationServices();// Para usar los servicios de extensiones (patrón unidad de trabajo)

builder.Services.AddDbContext<IncidenciasContext>(optionsBuilder => //Inyección del DB Context
{
    string  connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Se agregan las siguientes lineas de code (migracion)
using(var scope= app.Services.CreateScope()){
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try{
    var context = services.GetRequiredService<IncidenciasContext>();
    await context.Database.MigrateAsync();
    }
    catch(Exception ex){
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex,"Ocurrió un error durante la migración");
    }
}
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
