using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.Usuarios;

namespace ApiTiendaDulceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly ContextoVentas _context;

        public VentasController(ContextoVentas context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ventas = await _context.ventas.ToListAsync();
            return Ok(ventas);
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var venta = await _context.ventas.FindAsync(id);
            if (venta == null)
                return NotFound();

            return Ok(venta);
        }

        // POST: api/Ventas
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Ventas ventas)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.ventas.Add(ventas);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = ventas.Id }, ventas);
        }

        // PUT: api/Ventas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Ventas ventas)
        {
            if (id != ventas.Id)
                return BadRequest("El ID proporcionado no coincide con el del objeto.");

            _context.Entry(ventas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentasExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var venta = await _context.ventas.FindAsync(id);
            if (venta == null)
                return NotFound();

            _context.ventas.Remove(venta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentasExists(int id)
        {
            return _context.ventas.Any(e => e.Id == id);
        }
    }
}
