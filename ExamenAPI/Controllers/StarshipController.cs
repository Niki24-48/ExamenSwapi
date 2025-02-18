using ExamenAPI.Context;
using ExamenAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenAPI.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class StarshipController : ControllerBase
    {
        private readonly SwapiDBContext _context;

        public StarshipController(SwapiDBContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StarshipsShort>>> GetStarships()
        {
            return await _context.StarshipsShortV.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Starship>> GetStarshipByID(int id)
        {
            var starship = await _context.Starships.FindAsync(id);
            if (starship == null)
            {
                return NotFound();
            }
            return starship;
        }
        [HttpPost]
        public async Task<ActionResult<Starship>> PostStarship(Starship starship)
        {
            if (starship == null)
            {
                return BadRequest();
            }
            _context.Starships.Add(starship);
            await _context.SaveChangesAsync();
            return starship;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Starship>> PutStarship(int id, Starship starship)
        {
            if (id != starship.id)
            {
                return BadRequest();
            }
            _context.Starships.Update(starship);
            await _context.SaveChangesAsync();

            return starship;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStarship(int id)
        {
            var starship = await _context.Starships.FindAsync(id);
            if (starship == null)
            {
                return NotFound();
            }
            _context.Starships.Remove(starship);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
