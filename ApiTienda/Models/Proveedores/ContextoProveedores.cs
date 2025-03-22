using ApiTiendaDulceria.Models.Proveedores;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Contexto de base de datos para la entidad Proveedores.
/// Gestiona la conexión a la base de datos y las operaciones con la tabla Proveedores.
/// </summary>
public class ContextoProveedores : DbContext
{
    /// <summary>
    /// Constructor del contexto que recibe opciones de configuración.
    /// </summary>
    /// <param name="options">Opciones de configuración para el contexto.</param>
    public ContextoProveedores(DbContextOptions<ContextoProveedores> options) : base(options) { }

    /// <summary>
    /// Conjunto de datos que representa la tabla Proveedores en la base de datos.
    /// </summary>
    public DbSet<Proveedores> proveedores { get; set; }
}
