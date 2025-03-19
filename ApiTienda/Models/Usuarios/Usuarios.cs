namespace ApiTiendaDulceria.Models.Usuarios
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string identificacion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string password { get; set; }
        public int id_rol { get; set; }
        public int id_tipo_identificacion { get; set; }

    }
}
