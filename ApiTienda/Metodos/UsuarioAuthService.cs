using ApiTiendaDulceria.Models.Usuarios;

namespace ApiTiendaDulceria.Metodos
{
    public class UsuarioAuthService
    {
        private readonly ContextoUsuarios _context;

        public UsuarioAuthService(ContextoUsuarios context)
        {
            _context = context;
        }

        public Usuarios? Autenticar(string username, string password)
        {
            return _context.usuarios.FirstOrDefault(u =>
                u.identificacion == username && u.password == password);
        }
    }
}
