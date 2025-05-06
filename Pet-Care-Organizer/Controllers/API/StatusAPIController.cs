using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_Care_Organizer.Data;
using Pet_Care_Organizer.Models;

namespace Pet_Care_Organizer.Controllers.API
{
    [Route("api/status")]
    [ApiController]
    public class StatusAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatusAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StatusAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
        {
            return await _context.Status.ToListAsync();
        }

        // GET: api/StatusAPI/NEW
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatus(string id)  // Note: string parameter for StatusId
        {
            var status = await _context.Status.FindAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return status;
        }

        // PUT: api/StatusAPI/NEW
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(string id, Status status)  // Note: string parameter
        {
            if (id != status.StatusId)
            {
                return BadRequest();
            }

            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
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

        // POST: api/StatusAPI
        [HttpPost]
        public async Task<ActionResult<Status>> PostStatus(Status status)
        {
            _context.Status.Add(status);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StatusExists(status.StatusId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStatus", new { id = status.StatusId }, status);
        }

        // DELETE: api/StatusAPI/NEW
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(string id)  // Note: string parameter
        {
            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.Status.Remove(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusExists(string id)  // Note: string parameter
        {
            return _context.Status.Any(e => e.StatusId == id);
        }
    }
}