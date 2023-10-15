using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Domain.Entities;
using HMS.Persistence.Contexts;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NursesController : ControllerBase
    {
        private readonly HMSDbContext _context;

        public NursesController(HMSDbContext context)
        {
            _context = context;
        }

        // GET: api/Nurses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nurse>>> GetNurses()
        {
          if (_context.Nurses == null)
          {
              return NotFound();
          }
            return await _context.Nurses.ToListAsync();
        }

        // GET: api/Nurses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nurse>> GetNurse(Guid id)
        {
          if (_context.Nurses == null)
          {
              return NotFound();
          }
            var nurse = await _context.Nurses.FindAsync(id);

            if (nurse == null)
            {
                return NotFound();
            }

            return nurse;
        }

        // PUT: api/Nurses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNurse(Guid id, Nurse nurse)
        {
            if (id != nurse.Id)
            {
                return BadRequest();
            }

            _context.Entry(nurse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NurseExists(id))
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

        // POST: api/Nurses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nurse>> PostNurse(Nurse nurse)
        {
          if (_context.Nurses == null)
          {
              return Problem("Entity set 'HMSDbContext.Nurses'  is null.");
          }
            _context.Nurses.Add(nurse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNurse", new { id = nurse.Id }, nurse);
        }

        // DELETE: api/Nurses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNurse(Guid id)
        {
            if (_context.Nurses == null)
            {
                return NotFound();
            }
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse == null)
            {
                return NotFound();
            }

            _context.Nurses.Remove(nurse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NurseExists(Guid id)
        {
            return (_context.Nurses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
