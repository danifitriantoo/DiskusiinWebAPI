using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiskusiinWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using CoreApiResponse;

namespace DiskusiinWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentingsController : BaseController
    {
        private readonly RentingContext _context;

        public RentingsController(RentingContext context)
        {
            _context = context;
        }

        // GET: api/Rentings
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Rentings>>> GetRentings()
        {

          if (_context.Rentings == null)
          {
              return NotFound();
          }

            return await _context.Rentings.ToListAsync();
        }

        // GET: api/Rentings/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Rentings>> GetRentings(int id)
        {
          if (_context.Rentings == null)
          {
              return NotFound();
          }

            var rentings = await _context.Rentings.FindAsync(id);

            if (rentings == null)
            {
                return NotFound();
            }

            return Ok(rentings);
        }

        // PUT: api/Rentings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutRentings(int id, Rentings rentings)
        {
            if (id != rentings.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentingsExists(id))
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

        // POST: api/Rentings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Rentings>> PostRentings(Rentings rentings)
        {
          if (_context.Rentings == null)
          {
              return Problem("Entity set 'RentingContext.Rentings'  is null.");
          }
            _context.Rentings.Add(rentings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentings", new { id = rentings.Id }, rentings);
        }

        // DELETE: api/Rentings/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRentings(int id)
        {
            if (_context.Rentings == null)
            {
                return NotFound();
            }
            var rentings = await _context.Rentings.FindAsync(id);
            if (rentings == null)
            {
                return NotFound();
            }

            _context.Rentings.Remove(rentings);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentingsExists(int id)
        {
            return (_context.Rentings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
