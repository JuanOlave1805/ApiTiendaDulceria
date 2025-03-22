using Microsoft.EntityFrameworkCore;

namespace ApiTiendaDulceria.Models.DetalleVenta
{
    /// <summary>
    /// Contexto de base de datos para la entidad Ofertas.
    /// Gestiona la conexión a la base de datos y las operaciones con la tabla Detalles_Venta.
    /// </summary>
    public class ContextoDetalles_Venta : DbContext
    {
        /// <summary>
        /// Constructor del contexto que recibe opciones de configuración.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public ContextoDetalles_Venta(DbContextOptions<ContextoDetalles_Venta> options) : base(options) { }

        /// <summary>
        /// Conjunto de datos que representa la tabla Detalles_Venta en la base de datos.
        /// </summary>
        public DbSet<Detalles_Venta> detalles_ventas { get; set; }
    }
}
