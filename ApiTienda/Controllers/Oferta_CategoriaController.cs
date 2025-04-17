using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.Oferta_Categoria;

namespace ApiTiendaDulceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Oferta_CategoriaController : ControllerBase
    {
        private readonly ContextoOferta_Categoria _context;

        public Oferta_CategoriaController(ContextoOferta_Categoria context)
        {
            _context = context;
        }

        // GET: api/Oferta_Categoria
        [HttpGet]
        public async Task<IActionResult> GetOfertasCategoria()
        {
            var lista = await _context.ofertas_categoria.ToListAsync();
            return Ok(lista);
        }

        // GET: api/Oferta_Categoria/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfertaCategoria(int id)
        {
            var oferta = await _context.ofertas_categoria.FindAsync(id);

            if (oferta == null)
                return NotFound();

            return Ok(oferta);
        }

        // POST: api/Oferta_Categoria
        [HttpPost]
        public async Task<IActionResult> PostOfertaCategoria([FromBody] Oferta_Categoria oferta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.ofertas_categoria.Add(oferta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOfertaCategoria), new { id = oferta.Id }, oferta);
        }

        // PUT: api/Oferta_Categoria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfertaCategoria(int id, [FromBody] Oferta_Categoria oferta)
        {
            if (id != oferta.Id)
                return BadRequest("El ID no coincide.");

            _context.Entry(oferta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaCategoriaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Oferta_Categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfertaCategoria(int id)
        {
            var oferta = await _context.ofertas_categoria.FindAsync(id);
            if (oferta == null)
                return NotFound();

            _context.ofertas_categoria.Remove(oferta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfertaCategoriaExists(int id)
        {
            return _context.ofertas_categoria.Any(e => e.Id == id);
        }
    }
}
