using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.Roles;

namespace ApiTiendaDulceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly ContextoRoles _context;

        public RolesController(ContextoRoles context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene la lista de todos los roles.
        /// </summary>
        /// <returns>Lista de roles.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
        {
            return Ok(await _context.Roles.ToListAsync());
        }

        /// <summary>
        /// Obtiene un rol por su ID.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <returns>Objeto rol.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        /// <summary>
        /// Crea un nuevo rol.
        /// </summary>
        /// <param name="rol">Objeto rol.</param>
        /// <returns>Rol creado.</returns>
        [HttpPost]
        public async Task<ActionResult<Roles>> CreateRol([FromBody] Roles rol)
        {
            if (rol == null)
            {
                return BadRequest("El objeto no puede ser nulo.");
            }

            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRol), new { id = rol.Id }, rol);
        }

        /// <summary>
        /// Actualiza un rol existente.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <param name="rol">Objeto con los datos actualizados.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRol(int id, [FromBody] Roles rol)
        {
            if (id != rol.Id)
            {
                return BadRequest("El ID no coincide.");
            }

            _context.Entry(rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
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
        /// Elimina un rol por su ID.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Verifica si un rol existe en la base de datos.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <returns>True si existe, False si no.</returns>
        private bool RolExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
