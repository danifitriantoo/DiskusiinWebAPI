using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiskusiinWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace DiskusiinWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly RoomContext _context;

        public RoomsController(RoomContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetRooms()
        {

            if (_context.Rooms == null)
            {
                return NotFound();
            }

            return await _context.Rooms.ToListAsync();
        }
        // GET: api/Rooms/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Rooms>> GetRooms(long id)
        {
          if (_context.Rooms == null)
          {
              return NotFound();
          }
            var rooms = await _context.Rooms.FindAsync(id);

            if (rooms == null)
            {
                return NotFound();
            }

            return rooms;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutRooms(long id, Rooms rooms)
        {
            if (id != rooms.Id)
            {
                return BadRequest();
            }

            _context.Entry(rooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomsExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Rooms>> PostRooms(Rooms rooms)
        {
          if (_context.Rooms == null)
          {
              return Problem("Entity set 'RoomContext.Rooms'  is null.");
          }
            _context.Rooms.Add(rooms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRooms", new { id = rooms.Id }, rooms);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRooms(long id)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var rooms = await _context.Rooms.FindAsync(id);
            if (rooms == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(rooms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomsExists(long id)
        {
            return (_context.Rooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
