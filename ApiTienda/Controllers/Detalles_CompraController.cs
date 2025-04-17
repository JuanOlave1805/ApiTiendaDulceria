using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.DetalleCompra;

namespace ApiTiendaDulceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Detalles_CompraController : ControllerBase
    {
        private readonly ContextoDetalle_Compra _context;

        public Detalles_CompraController(ContextoDetalle_Compra context)
        {
            _context = context;
        }

        // GET: api/Detalles_Compra
        [HttpGet]
        public async Task<IActionResult> GetDetallesCompra()
        {
            var detalles = await _context.detalles_compra.ToListAsync();
            return Ok(detalles);
        }

        // GET: api/Detalles_Compra/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalleCompra(int id)
        {
            var detalle = await _context.detalles_compra.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            return Ok(detalle);
        }

        // POST: api/Detalles_Compra
        [HttpPost]
        public async Task<IActionResult> PostDetalleCompra([FromBody] Detalles_Compra detalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.detalles_compra.Add(detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetalleCompra), new { id = detalle.Id }, detalle);
        }

        // PUT: api/Detalles_Compra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleCompra(int id, [FromBody] Detalles_Compra detalle)
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
                if (!DetalleCompraExists(id))
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

        // DELETE: api/Detalles_Compra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleCompra(int id)
        {
            var detalle = await _context.detalles_compra.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            _context.detalles_compra.Remove(detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleCompraExists(int id)
        {
            return _context.detalles_compra.Any(e => e.Id == id);
        }
    }
}
