using ExamenAPI.Context;
using ExamenAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenAPI.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class SpeciesController :ControllerBase
    {
        private readonly SwapiDBContext _context;

        public SpeciesController(SwapiDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specie>>> GetSpecies()
        {
            return await _context.Species.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Specie>> GetSpecieByID(int id)
        {
            var specie = await _context.Species.FindAsync(id);
            if (specie == null)
            {
                return NotFound();
            }
            return specie;
        }

        [HttpPost]
        public async Task<ActionResult<Specie>> PostSpecies(Specie specie)
        {
            if (specie == null)
            {
                return BadRequest();
            }
            _context.Species.Add(specie);
            await _context.SaveChangesAsync();
            return specie;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Specie>> PutSpecie(int id, Specie specie)
        {
            if (id != specie.id)
            {
                return BadRequest();
            }
            _context.Species.Update(specie);
            await _context.SaveChangesAsync();

            return specie;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSpecie(int id)
        {
            var specie = await _context.Species.FindAsync(id);
            if (specie == null)
            {
                return NotFound();
            }
            _context.Species.Remove(specie);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
