using Microsoft.EntityFrameworkCore;

namespace ApiTiendaDulceria.Models.Compras
{
    /// <summary>
    /// Contexto de base de datos para la entidad Ofertas.
    /// Gestiona la conexión a la base de datos y las operaciones con la tabla Compras.
    /// </summary>
    public class ContextoCompras : DbContext
    {
        /// <summary>
        /// Constructor del contexto que recibe opciones de configuración.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public ContextoCompras(DbContextOptions<ContextoCompras> options) : base(options) { }

        /// <summary>
        /// Conjunto de datos que representa la tabla Compras en la base de datos.
        /// </summary>
        public DbSet<Compras> compras { get; set; }
    }
}
