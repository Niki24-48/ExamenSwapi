using ExamenAPI.Context;
using ExamenAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenAPI.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly SwapiDBContext _context;

        public VehiclesController(SwapiDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicleByID(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest();
            }
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Vehicle>> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.id)
            {
                return BadRequest();
            }
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
