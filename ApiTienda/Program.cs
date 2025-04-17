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

var builder = WebApplication.CreateBuilder(args);

// Obtener cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Configurar DbContext para SQL Server -- Contexto Categorias
builder.Services.AddDbContext<ContextoCategorias>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Clientes
builder.Services.AddDbContext<ContextoClientes>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Compras
builder.Services.AddDbContext<ContextoCompras>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Detalle Compra
builder.Services.AddDbContext<ContextoDetalle_Compra>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Detalle Venta
builder.Services.AddDbContext<ContextoDetalles_Venta>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Oferta Categoria
builder.Services.AddDbContext<ContextoOferta_Categoria>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Ofertas
builder.Services.AddDbContext<ContextoOfertas>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Producto Categorias
builder.Services.AddDbContext<ContextoProducto_Categoria>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Productos
builder.Services.AddDbContext<ContextoProductos>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Proveedores
builder.Services.AddDbContext<ContextoProveedores>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Roles
builder.Services.AddDbContext<ContextoRoles>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Tipos Documentos
builder.Services.AddDbContext<ContextoTipoIdentificacion>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Usuarios
builder.Services.AddDbContext<ContextoProveedores>(options =>
    options.UseSqlServer(connectionString));

// Configurar DbContext para SQL Server -- Contexto Ventas
builder.Services.AddDbContext<ContextoVentas>(options =>
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
