using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.Tipos_Identificacion;
using ApiTiendaDulceria.Models.Roles;
using ApiTiendaDulceria.Models.Clientes;
using ApiTiendaDulceria.Models.Categorias;
using ApiTiendaDulceria.Models.Compras;
using ApiTiendaDulceria.Models.DetalleCompra;
using ApiTiendaDulceria.Models.DetalleVenta;
using ApiTiendaDulceria.Models.Oferta_Categoria;
using ApiTiendaDulceria.Models.Ofertas;
using ApiTiendaDulceria.Models.Producto_Categoria;
using ApiTiendaDulceria.Metodos;

var builder = WebApplication.CreateBuilder(args);

// Obtener cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5500", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configurar DbContexts
builder.Services.AddDbContext<ContextoCategorias>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoClientes>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoCompras>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoDetalle_Compra>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoDetalles_Venta>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoOferta_Categoria>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoOfertas>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoProducto_Categoria>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoProductos>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoProveedores>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoRoles>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoTipoIdentificacion>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoUsuarios>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ContextoVentas>(options =>
    options.UseSqlServer(connectionString));

// Servicio de autenticación
builder.Services.AddScoped<UsuarioAuthService>();

// Swagger
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

// Usar CORS (debe estar antes de Authorization)
app.UseCors("AllowLocalhost5500");

// Middleware de autenticación por encabezados
app.Use(async (context, next) =>
{
    // Permitir el acceso sin autenticación solo al endpoint de login
    if (context.Request.Path.StartsWithSegments("/api/Usuarios/Login", StringComparison.OrdinalIgnoreCase))
    {
        await next();
        return;
    }

    var username = context.Request.Headers["username"].ToString();
    var password = context.Request.Headers["password"].ToString();

    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Credenciales no proporcionadas");
        return;
    }

    using var scope = app.Services.CreateScope();
    var authService = scope.ServiceProvider.GetRequiredService<UsuarioAuthService>();
    var usuario = authService.Autenticar(username, password);

    if (usuario == null)
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Credenciales inválidas");
        return;
    }

    await next();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
