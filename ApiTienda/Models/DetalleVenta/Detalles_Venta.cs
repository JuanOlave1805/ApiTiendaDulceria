namespace ApiTiendaDulceria.Models.DetalleVenta
{
    public class Detalles_Venta
    {
        public int Id { get; set; }
        public int id_venta { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal descuento_aplicado { get; set; }
        public decimal precio_final { get; set; }
    }
}
