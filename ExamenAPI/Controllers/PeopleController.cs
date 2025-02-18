using ExamenAPI.Context;
using ExamenAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenAPI.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly SwapiDBContext _context;

        public PeopleController (SwapiDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<People>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetPeopleByID(int id)
        {
            var people = await _context.People.FindAsync(id);
            if(people == null)
            {
                return NotFound();
            }
            return people;
        }

        [HttpPost]
        public async Task<ActionResult<People>> PostPeople(People people)
        {
            if(people == null)
            {
                return BadRequest();
            }
            _context.People.Add(people);
            await _context.SaveChangesAsync();
            return people;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<People>> PutPeople(int id , People people)
        {
            if(id != people.id)
            {
                return BadRequest();
            }
            _context.People.Update(people);
            await _context.SaveChangesAsync();

            return people;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePeople(int id)
        {
            var people = await _context.People.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }
            _context.People.Remove(people);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
