using ApiTienda.Models;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Contexto de base de datos para la entidad Usuarios.
/// Gestiona la conexión a la base de datos y las operaciones con la tabla Usuarios.
/// </summary>
public class ContextoUsuarios : DbContext
{
    /// <summary>
    /// Constructor del contexto que recibe opciones de configuración.
    /// </summary>
    /// <param name="options">Opciones de configuración para el contexto.</param>
    public ContextoUsuarios(DbContextOptions<ContextoUsuarios> options) : base(options) { }

    /// <summary>
    /// Conjunto de datos que representa la tabla Usuarios en la base de datos.
    /// </summary>
    public DbSet<Usuarios> usuarios { get; set; }
}
