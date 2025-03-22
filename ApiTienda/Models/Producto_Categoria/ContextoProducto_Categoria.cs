using Microsoft.EntityFrameworkCore;

namespace ApiTiendaDulceria.Models.Producto_Categoria
{
    /// <summary>
    /// Contexto de base de datos para la entidad Producto_Categoria.
    /// Gestiona la conexión a la base de datos y las operaciones con la tabla Producto_Categoria.
    /// </summary>
    public class ContextoProducto_Categoria : DbContext
    {
        /// <summary>
        /// Constructor del contexto que recibe opciones de configuración.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public ContextoProducto_Categoria(DbContextOptions<ContextoProducto_Categoria> options) : base(options) { }

        /// <summary>
        /// Conjunto de datos que representa la tabla Producto_Categoria en la base de datos.
        /// </summary>
        public DbSet<Producto_Categoria> producto_categoria { get; set; }
    }
}
