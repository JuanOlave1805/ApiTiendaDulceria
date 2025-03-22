using ApiTiendaDulceria.Models.DetalleVenta;
using Microsoft.EntityFrameworkCore;

namespace ApiTiendaDulceria.Models.DetalleCompra
{
    /// <summary>
    /// Contexto de base de datos para la entidad Ofertas.
    /// Gestiona la conexión a la base de datos y las operaciones con la tabla Detalles_Compra.
    /// </summary>
    public class ContextoDetalle_Compra : DbContext
    {
        /// <summary>
        /// Constructor del contexto que recibe opciones de configuración.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public ContextoDetalle_Compra(DbContextOptions<ContextoDetalle_Compra> options) : base(options) { }

        /// <summary>
        /// Conjunto de datos que representa la tabla Detalles_Compra en la base de datos.
        /// </summary>
        public DbSet<Detalles_Compra> detalles_compra { get; set; }
    }
}
