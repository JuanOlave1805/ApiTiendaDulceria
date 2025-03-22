using ApiTiendaDulceria.Models.Clientes;
using Microsoft.EntityFrameworkCore;

namespace ApiTiendaDulceria.Models.Categorias
{
    /// <summary>
    /// Contexto de base de datos para la entidad Categorias.
    /// Gestiona la conexión a la base de datos y las operaciones con la tabla Categorias.
    /// </summary>
    public class ContextoCategorias : DbContext
    {
        /// <summary>
        /// Constructor del contexto que recibe opciones de configuración.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public ContextoCategorias(DbContextOptions<ContextoCategorias> options) : base(options) { }

        /// <summary>
        /// Conjunto de datos que representa la tabla Categorias en la base de datos.
        /// </summary>
        public DbSet<Categorias> categorias { get; set; }
    }
}
