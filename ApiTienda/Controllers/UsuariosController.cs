using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.Usuarios;

namespace ApiTiendaDulceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ContextoUsuarios _context;

        public UsuariosController(ContextoUsuarios context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene la lista de todos los usuarios.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsers()
        {
            return Ok(await _context.usuarios.ToListAsync());
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns>Objeto usuario.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUser(int id) // Cambiado a int para coincidir con la BD
        {
            var user = await _context.usuarios.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="user">Objeto usuario.</param>
        /// <returns>Usuario creado.</returns>
        [HttpPost]
        public async Task<ActionResult<Usuarios>> CreateUser([FromBody] Usuarios user)
        {
            if (user == null)
            {
                return BadRequest("El usuario no puede ser nulo.");
            }

            _context.usuarios.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <param name="user">Objeto usuario con los datos actualizados.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Usuarios user)
        {
            if (id != user.Id)
            {
                return BadRequest("El ID en la URL no coincide con el ID del usuario.");
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) // Cambiado a int para coincidir con la BD
        {
            var user = await _context.usuarios.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.usuarios.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Verifica si un usuario existe en la base de datos.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns>True si existe, False si no.</returns>
        private bool UserExists(int id)
        {
            return _context.usuarios.Any(e => e.Id == id);
        }
    }
}