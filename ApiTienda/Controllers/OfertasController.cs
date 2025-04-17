using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiendaDulceria.Models.Ofertas;

namespace ApiTiendaDulceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfertasController : ControllerBase
    {
        private readonly ContextoOfertas _context;

        public OfertasController(ContextoOfertas context)
        {
            _context = context;
        }

        // GET: api/Ofertas
        [HttpGet]
        public async Task<IActionResult> GetOfertas()
        {
            var lista = await _context.ofertas.ToListAsync();
            return Ok(lista);
        }

        // GET: api/Ofertas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOferta(int id)
        {
            var oferta = await _context.ofertas.FindAsync(id);

            if (oferta == null)
                return NotFound();

            return Ok(oferta);
        }

        // POST: api/Ofertas
        [HttpPost]
        public async Task<IActionResult> PostOferta([FromBody] Ofertas oferta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.ofertas.Add(oferta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOferta), new { id = oferta.Id }, oferta);
        }

        // PUT: api/Ofertas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOferta(int id, [FromBody] Ofertas oferta)
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
                if (!OfertaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Ofertas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOferta(int id)
        {
            var oferta = await _context.ofertas.FindAsync(id);
            if (oferta == null)
                return NotFound();

            _context.ofertas.Remove(oferta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfertaExists(int id)
        {
            return _context.ofertas.Any(e => e.Id == id);
        }
    }
}
