using ApiTiendaDulceria.Models.Compras;
using Microsoft.EntityFrameworkCore;

namespace ApiTiendaDulceria.Models.Clientes
{
    /// <summary>
    /// Contexto de base de datos para la entidad Clientes.
    /// Gestiona la conexión a la base de datos y las operaciones con la tabla Clientes.
    /// </summary>
    public class ContextoClientes : DbContext
    {
        /// <summary>
        /// Constructor del contexto que recibe opciones de configuración.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public ContextoClientes(DbContextOptions<ContextoClientes> options) : base(options) { }

        /// <summary>
        /// Conjunto de datos que representa la tabla Clientes en la base de datos.
        /// </summary>
        public DbSet<Clientes> clientes { get; set; }
    }
}
