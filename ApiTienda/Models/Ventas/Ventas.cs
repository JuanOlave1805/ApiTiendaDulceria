namespace ApiTiendaDulceria.Models.Usuarios
{
    public class Ventas
    {
        public int Id { get; set; }
        public int id_cliente { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha_venta { get; set; }
        public decimal total { get; set; }
    }
}
