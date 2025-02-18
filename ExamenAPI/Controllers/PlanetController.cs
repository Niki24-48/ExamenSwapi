using ExamenAPI.Context;
using ExamenAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenAPI.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly SwapiDBContext _context;

        public PlanetController(SwapiDBContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> GetPlanets()
        {
            return await _context.Planets.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Planet>> GetPlanetByID(int id)
        {
            var planet = await _context.Planets.FindAsync(id);
            if (planet == null)
            {
                return NotFound();
            }
            return planet;
        }

        [HttpPost]
        public async Task<ActionResult<Planet>> PostPlanet(Planet planet)
        {
            if (planet == null)
            {
                return BadRequest();
            }
            _context.Planets.Add(planet);
            await _context.SaveChangesAsync();
            return planet;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Planet>> PutPlanet(int id, Planet planet)
        {
            if (id != planet.id)
            {
                return BadRequest();
            }
            _context.Planets.Update(planet);
            await _context.SaveChangesAsync();

            return planet;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlanet(int id)
        {
            var planet = await _context.Planets.FindAsync(id);
            if (planet == null)
            {
                return NotFound();
            }
            _context.Planets.Remove(planet);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
