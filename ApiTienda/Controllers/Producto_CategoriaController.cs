using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.Producto_Categoria;

namespace ApiTiendaDulceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Producto_CategoriaController : ControllerBase
    {
        private readonly ContextoProducto_Categoria _context;

        public Producto_CategoriaController(ContextoProducto_Categoria context)
        {
            _context = context;
        }

        // GET: api/Producto_Categoria
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _context.producto_categoria.ToListAsync();
            return Ok(lista);
        }

        // GET: api/Producto_Categoria/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.producto_categoria.FindAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/Producto_Categoria
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Producto_Categoria producto_Categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.producto_categoria.Add(producto_Categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = producto_Categoria.Id }, producto_Categoria);
        }

        // PUT: api/Producto_Categoria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Producto_Categoria producto_Categoria)
        {
            if (id != producto_Categoria.Id)
                return BadRequest("El ID proporcionado no coincide con el del objeto.");

            _context.Entry(producto_Categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Producto_CategoriaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Producto_Categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto_Categoria = await _context.producto_categoria.FindAsync(id);
            if (producto_Categoria == null)
                return NotFound();

            _context.producto_categoria.Remove(producto_Categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Producto_CategoriaExists(int id)
        {
            return _context.producto_categoria.Any(e => e.Id == id);
        }
    }
}
