namespace ApiTiendaDulceria.Models.Ofertas
{
    public class Ofertas
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public decimal porcentaje_descuento { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
    }
}
