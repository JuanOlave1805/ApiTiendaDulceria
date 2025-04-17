using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.Proveedores;

namespace ApiTiendaDulceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : ControllerBase
    {
        private readonly ContextoProveedores _context;

        public ProveedoresController(ContextoProveedores context)
        {
            _context = context;
        }

        // GET: api/Proveedores
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _context.proveedores.ToListAsync();
            return Ok(proveedores);
        }

        // GET: api/Proveedores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var proveedor = await _context.proveedores.FindAsync(id);
            if (proveedor == null)
                return NotFound();

            return Ok(proveedor);
        }

        // POST: api/Proveedores
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Proveedores proveedores)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.proveedores.Add(proveedores);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = proveedores.Id }, proveedores);
        }

        // PUT: api/Proveedores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Proveedores proveedores)
        {
            if (id != proveedores.Id)
                return BadRequest("El ID proporcionado no coincide con el del objeto.");

            _context.Entry(proveedores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedoresExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Proveedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var proveedor = await _context.proveedores.FindAsync(id);
            if (proveedor == null)
                return NotFound();

            _context.proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProveedoresExists(int id)
        {
            return _context.proveedores.Any(e => e.Id == id);
        }
    }
}
