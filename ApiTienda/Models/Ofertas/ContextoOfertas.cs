using Microsoft.EntityFrameworkCore;

namespace ApiTiendaDulceria.Models.Ofertas
{
    /// <summary>
    /// Contexto de base de datos para la entidad Ofertas.
    /// Gestiona la conexión a la base de datos y las operaciones con la tabla Ofertas.
    /// </summary>
    public class ContextoOfertas : DbContext
    {
        /// <summary>
        /// Constructor del contexto que recibe opciones de configuración.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public ContextoOfertas(DbContextOptions<ContextoOfertas> options) : base(options) { }

        /// <summary>
        /// Conjunto de datos que representa la tabla Ofertas en la base de datos.
        /// </summary>
        public DbSet<Ofertas> ofertas { get; set; }
    }
}
