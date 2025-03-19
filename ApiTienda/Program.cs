using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.Tipos_Identificacion;

var builder = WebApplication.CreateBuilder(args);

// Obtener cadena de conexi�n desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Configurar DbContext para SQL Server -- Contexto Usuarios
builder.Services.AddDbContext<ContextoUsuarios>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Tipos Documentos
builder.Services.AddDbContext<ContextoTipoIdentificacion>(options =>
    options.UseSqlServer(connectionString));

// Habilitar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
