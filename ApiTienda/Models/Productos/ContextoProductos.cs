using ApiTiendaDulceria.Models.Productos;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Contexto de base de datos para la entidad Productos.
/// Gestiona la conexión a la base de datos y las operaciones con la tabla Productos.
/// </summary>
public class ContextoProductos : DbContext
{
    /// <summary>
    /// Constructor del contexto que recibe opciones de configuración.
    /// </summary>
    /// <param name="options">Opciones de configuración para el contexto.</param>
    public ContextoProductos(DbContextOptions<ContextoProductos> options) : base(options) { }

    /// <summary>
    /// Conjunto de datos que representa la tabla Productos en la base de datos.
    /// </summary>
    public DbSet<Productos> productos { get; set; }
}
