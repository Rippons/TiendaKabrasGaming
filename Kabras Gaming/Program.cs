using Kabras_Gaming.Controllers.Data.Repositories;
using Kabras_Gaming.Controllers.Data.Repositories.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using UserAuthApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar MongoDB
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings"));

// Registrar IMongoClient como Singleton
builder.Services.AddSingleton<IMongoClient>(s =>
{
    var settings = s.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

// Registrar IUserRepository e implementación UserRepository
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(); // Agregar esta línea para el repositorio de usuarios

// Registrar IProductoRepository e implementación ProducRepository
builder.Services.AddScoped<IProductoRepository, ProducRepository>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Añadir servicios de controladores
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


