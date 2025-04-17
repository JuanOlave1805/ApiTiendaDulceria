using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.Productos;

namespace ApiTiendaDulceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ContextoProductos _context;

        public ProductosController(ContextoProductos context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _context.productos.ToListAsync();
            return Ok(productos);
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _context.productos.FindAsync(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Productos productos)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.productos.Add(productos);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = productos.Id }, productos);
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Productos productos)
        {
            if (id != productos.Id)
                return BadRequest("El ID proporcionado no coincide con el del objeto.");

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.productos.FindAsync(id);
            if (producto == null)
                return NotFound();

            _context.productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductosExists(int id)
        {
            return _context.productos.Any(e => e.Id == id);
        }
    }
}
