namespace ApiTiendaDulceria.Models.Clientes
{
    public class Clientes
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_registro { get; set; }
        public string documento { get; set; }
    }
}
