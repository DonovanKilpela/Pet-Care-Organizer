using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_Care_Organizer.Data;
using Pet_Care_Organizer.Models;

namespace Pet_Care_Organizer.Controllers.API
{
    [Route("api/supplies")]
    [ApiController]
    public class SuppliesAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SuppliesAPIController(ApplicationDbContext context)
        {
            _context = context;
        }
   
        // GET: api/SuppliesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplies>>> GetSupplies()
        {
            return await _context.Supplies.ToListAsync();
        }
    
        // GET: api/SuppliesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplies>> GetSupplies(int id)
        {
            var supplies = await _context.Supplies.FindAsync(id);

            if (supplies == null)
            {
                return NotFound();
            }

            return supplies;
        }

        // PUT: api/SuppliesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplies(int id, Supplies supplies)
        {
            if (id != supplies.Id)
            {
                return BadRequest();
            }

            _context.Entry(supplies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuppliesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SuppliesApi
        [HttpPost]
        public async Task<ActionResult<Supplies>> PostSupplies(Supplies supplies)
        {
            _context.Supplies.Add(supplies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupplies", new { id = supplies.Id }, supplies);
        }

        // DELETE: api/SuppliesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplies(int id)
        {
            var supplies = await _context.Supplies.FindAsync(id);
            if (supplies == null)
            {
                return NotFound();
            }

            _context.Supplies.Remove(supplies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuppliesExists(int id)
        {
            return _context.Supplies.Any(e => e.Id == id);
        }
    }
}