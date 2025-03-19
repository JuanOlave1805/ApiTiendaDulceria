using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.Tipos_Identificacion;

namespace ApiTiendaDulceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoIdentificacionesController : ControllerBase
    {
        private readonly ContextoTipoIdentificacion _context;

        public TipoIdentificacionesController(ContextoTipoIdentificacion context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene la lista de todos los tipos de identificación.
        /// </summary>
        /// <returns>Lista de tipos de identificación.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoIdentificacion>>> GetTiposIdentificacion()
        {
            return Ok(await _context.TipoIdentificacion.ToListAsync());
        }

        /// <summary>
        /// Obtiene un tipo de identificación por su ID.
        /// </summary>
        /// <param name="id">ID del tipo de identificación.</param>
        /// <returns>Objeto tipo de identificación.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoIdentificacion>> GetTipoIdentificacion(int id)
        {
            var tipoIdentificacion = await _context.TipoIdentificacion.FindAsync(id);

            if (tipoIdentificacion == null)
            {
                return NotFound();
            }

            return Ok(tipoIdentificacion);
        }

        /// <summary>
        /// Crea un nuevo tipo de identificación.
        /// </summary>
        /// <param name="tipoIdentificacion">Objeto tipo de identificación.</param>
        /// <returns>Tipo de identificación creado.</returns>
        [HttpPost]
        public async Task<ActionResult<TipoIdentificacion>> CreateTipoIdentificacion([FromBody] TipoIdentificacion tipoIdentificacion)
        {
            if (tipoIdentificacion == null)
            {
                return BadRequest("El objeto no puede ser nulo.");
            }

            _context.TipoIdentificacion.Add(tipoIdentificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoIdentificacion), new { id = tipoIdentificacion.Id }, tipoIdentificacion);
        }

        /// <summary>
        /// Actualiza un tipo de identificación existente.
        /// </summary>
        /// <param name="id">ID del tipo de identificación.</param>
        /// <param name="tipoIdentificacion">Objeto con los datos actualizados.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoIdentificacion(int id, [FromBody] TipoIdentificacion tipoIdentificacion)
        {
            if (id != tipoIdentificacion.Id)
            {
                return BadRequest("El ID no coincide.");
            }

            _context.Entry(tipoIdentificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoIdentificacionExists(id))
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
        /// Elimina un tipo de identificación por su ID.
        /// </summary>
        /// <param name="id">ID del tipo de identificación.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoIdentificacion(int id)
        {
            var tipoIdentificacion = await _context.TipoIdentificacion.FindAsync(id);
            if (tipoIdentificacion == null)
            {
                return NotFound();
            }

            _context.TipoIdentificacion.Remove(tipoIdentificacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Verifica si un tipo de identificación existe en la base de datos.
        /// </summary>
        /// <param name="id">ID del tipo de identificación.</param>
        /// <returns>True si existe, False si no.</returns>
        private bool TipoIdentificacionExists(int id)
        {
            return _context.TipoIdentificacion.Any(e => e.Id == id);
        }
    }
}
