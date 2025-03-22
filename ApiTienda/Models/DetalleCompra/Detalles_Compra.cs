namespace ApiTiendaDulceria.Models.DetalleCompra
{
    public class Detalles_Compra
    {
        public int Id { get; set; }
        public int id_compra { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
    }
}
