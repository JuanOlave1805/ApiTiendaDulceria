using ApiTiendaDulceria.Models.Oferta_Categoria;
using Microsoft.EntityFrameworkCore;

namespace ApiTiendaDulceria.Models.Ofertas
{
    /// <summary>
    /// Contexto de base de datos para la entidad Ofertas.
    /// Gestiona la conexión a la base de datos y las operaciones con la tabla Ofertas.
    /// </summary>
    public class ContextoOferta_Categoria : DbContext
    {
        /// <summary>
        /// Constructor del contexto que recibe opciones de configuración.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public ContextoOferta_Categoria(DbContextOptions<ContextoOferta_Categoria> options) : base(options) { }

        /// <summary>
        /// Conjunto de datos que representa la tabla Ofertas en la base de datos.
        /// </summary>
        public DbSet<Ofertas> ofertas { get; set; }
    }
}
