using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingAppReact.Data;
using TrackingAppReact.Models;

namespace TrackingAppReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InboxController : ControllerBase
    {
        private readonly TrackingDBContext _context;

        public InboxController(TrackingDBContext context)
        {
            _context = context;
        }

        // GET: api/Inbox
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inbox>>> GetInbox()
        {
          if (_context.Inbox == null)
          {
              return NotFound();
          }
            return await _context.Inbox.ToListAsync();
        }

        // GET: api/Inbox/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inbox>> GetInbox(int id)
        {
          if (_context.Inbox == null)
          {
              return NotFound();
          }
            var inbox = await _context.Inbox.FindAsync(id);

            if (inbox == null)
            {
                return NotFound();
            }

            return inbox;
        }

        // PUT: api/Inbox/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInbox(int id, Inbox inbox)
        {
            if (id != inbox.ID)
            {
                return BadRequest();
            }

            _context.Entry(inbox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InboxExists(id))
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

        // POST: api/Inbox
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inbox>> PostInbox(Inbox inbox)
        {
            if (_context.Inbox == null)
            {
                return Problem("Entity set 'TrackingDBContext.Inbox'  is null.");
            }

            _context.Inbox.Add(inbox);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInbox", new { id = inbox.ID }, inbox);
        }

        // DELETE: api/Inbox/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInbox(int id)
        {
            if (_context.Inbox == null)
            {
                return NotFound();
            }
            var inbox = await _context.Inbox.FindAsync(id);
            if (inbox == null)
            {
                return NotFound();
            }

            _context.Inbox.Remove(inbox);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InboxExists(int id)
        {
            return (_context.Inbox?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
