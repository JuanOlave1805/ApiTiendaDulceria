using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.Compras;

namespace ApiTiendaDulceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly ContextoCompras _context;

        public ComprasController(ContextoCompras context)
        {
            _context = context;
        }

        // GET: api/Compras
        [HttpGet]
        public async Task<IActionResult> GetCompras()
        {
            var compras = await _context.compras.ToListAsync();
            return Ok(compras);
        }

        // GET: api/Compras/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompra(int id)
        {
            var compra = await _context.compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }

            return Ok(compra);
        }

        // POST: api/Compras
        [HttpPost]
        public async Task<IActionResult> PostCompra([FromBody] Compras compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.compras.Add(compra);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompra), new { id = compra.Id }, compra);
        }

        // PUT: api/Compras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompra(int id, [FromBody] Compras compra)
        {
            if (id != compra.Id)
            {
                return BadRequest("El ID de la compra no coincide.");
            }

            _context.Entry(compra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(id))
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

        // DELETE: api/Compras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            var compra = await _context.compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }

            _context.compras.Remove(compra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompraExists(int id)
        {
            return _context.compras.Any(e => e.Id == id);
        }
    }
}
