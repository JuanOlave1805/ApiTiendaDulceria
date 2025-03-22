namespace ApiTiendaDulceria.Models.Compras
{
    public class Compras
    {
        public int Id { get; set; }
        public int id_proveedor { get; set; }
        public DateTime fecha_compra { get; set; }
        public decimal total { get; set; }
    }
}
