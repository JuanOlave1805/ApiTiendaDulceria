namespace ApiTiendaDulceria.Models.Productos
{
    public class Productos
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio_venta { get; set; }
        public int stock_actual { get; set; }
    }
}
