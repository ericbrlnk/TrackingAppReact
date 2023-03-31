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
    public class OrderChangeController : ControllerBase
    {
        private readonly TrackingDBContext _context;

        public OrderChangeController(TrackingDBContext context)
        {
            _context = context;
        }

        // GET: api/ReservationChange
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderChange>>> GetReservationChange()
        {
          if (_context.OrderChange == null)
          {
              return NotFound();
          }
            return await _context.OrderChange.ToListAsync();
        }

        // GET: api/ReservationChange/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderChange>> GetReservationChange(int id)
        {
          if (_context.OrderChange == null)
          {
              return NotFound();
          }
            var reservationChange = await _context.OrderChange.FindAsync(id);

            if (reservationChange == null)
            {
                return NotFound();
            }

            return reservationChange;
        }

        // PUT: api/ReservationChange/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservationChange(int id, OrderChange reservationChange)
        {
            if (id != reservationChange.ID)
            {
                return BadRequest();
            }

            _context.Entry(reservationChange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationChangeExists(id))
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

        // POST: api/ReservationChange
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderChange>> PostReservationChange(OrderChange reservationChange)
        {
          if (_context.OrderChange == null)
          {
              return Problem("Entity set 'TrackingDBContext.ReservationChange'  is null.");
          }
            _context.OrderChange.Add(reservationChange);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservationChange", new { id = reservationChange.ID }, reservationChange);
        }

        // DELETE: api/ReservationChange/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationChange(int id)
        {
            if (_context.OrderChange == null)
            {
                return NotFound();
            }
            var reservationChange = await _context.OrderChange.FindAsync(id);
            if (reservationChange == null)
            {
                return NotFound();
            }

            _context.OrderChange.Remove(reservationChange);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationChangeExists(int id)
        {
            return (_context.OrderChange?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
