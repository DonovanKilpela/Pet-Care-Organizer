using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_Care_Organizer.Data;
using Pet_Care_Organizer.Models;

namespace Pet_Care_Organizer.Controllers.API
{
    [Route("api/dailytasks")]
    [ApiController]
    public class DailyTasksAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DailyTasksAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DailyTasksAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyTasks>>> GetDailyTasks()
        {
            return await _context.DailyTasks
                .Include(d => d.Status)  // Include the Status navigation property
                .ToListAsync();
        }

        // GET: api/DailyTasksAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyTasks>> GetDailyTasks(int id)
        {
            var dailyTasks = await _context.DailyTasks
                .Include(d => d.Status)  // Include the Status navigation property
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dailyTasks == null)
            {
                return NotFound();
            }

            return dailyTasks;
        }

        // PUT: api/DailyTasksAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyTasks(int id, DailyTasks dailyTasks)
        {
            if (id != dailyTasks.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyTasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyTasksExists(id))
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

        // POST: api/DailyTasksAPI
        [HttpPost]
        public async Task<ActionResult<DailyTasks>> PostDailyTasks(DailyTasks dailyTasks)
        {
            _context.DailyTasks.Add(dailyTasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyTasks", new { id = dailyTasks.Id }, dailyTasks);
        }

        // DELETE: api/DailyTasksAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyTasks(int id)
        {
            var dailyTasks = await _context.DailyTasks.FindAsync(id);
            if (dailyTasks == null)
            {
                return NotFound();
            }

            _context.DailyTasks.Remove(dailyTasks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DailyTasksExists(int id)
        {
            return _context.DailyTasks.Any(e => e.Id == id);
        }
    }
}