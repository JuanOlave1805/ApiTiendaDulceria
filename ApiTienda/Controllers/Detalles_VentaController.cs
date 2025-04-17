using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.DetalleVenta;

namespace ApiTiendaDulceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Detalles_VentaController : ControllerBase
    {
        private readonly ContextoDetalles_Venta _context;

        public Detalles_VentaController(ContextoDetalles_Venta context)
        {
            _context = context;
        }

        // GET: api/Detalles_Venta
        [HttpGet]
        public async Task<IActionResult> GetDetallesVenta()
        {
            var detalles = await _context.detalles_ventas.ToListAsync();
            return Ok(detalles);
        }

        // GET: api/Detalles_Venta/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalleVenta(int id)
        {
            var detalle = await _context.detalles_ventas.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            return Ok(detalle);
        }

        // POST: api/Detalles_Venta
        [HttpPost]
        public async Task<IActionResult> PostDetalleVenta([FromBody] Detalles_Venta detalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.detalles_ventas.Add(detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetalleVenta), new { id = detalle.Id }, detalle);
        }

        // PUT: api/Detalles_Venta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleVenta(int id, [FromBody] Detalles_Venta detalle)
        {
            if (id != detalle.Id)
            {
                return BadRequest("El ID no coincide.");
            }

            _context.Entry(detalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleVentaExists(id))
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

        // DELETE: api/Detalles_Venta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleVenta(int id)
        {
            var detalle = await _context.detalles_ventas.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            _context.detalles_ventas.Remove(detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleVentaExists(int id)
        {
            return _context.detalles_ventas.Any(e => e.Id == id);
        }
    }
}
