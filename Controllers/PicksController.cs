using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_FB.Models;
using API_FB.Models.Contexts;

namespace API_FB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicksController : ControllerBase
    {
        private readonly PicksContext _context;

        public PicksController(PicksContext context)
        {
            _context = context;
        }

        // GET: api/Picks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pick>>> GetPicks()
        {
          if (_context.Picks == null)
          {
              return NotFound();
          }
            return await _context.Picks.ToListAsync();
        }

        // GET: api/Picks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pick>> GetPick(int id)
        {
          if (_context.Picks == null)
          {
              return NotFound();
          }
            var pick = await _context.Picks.FindAsync(id);

            if (pick == null)
            {
                return NotFound();
            }

            return pick;
        }

        // PUT: api/Picks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPick(int id, Pick pick)
        {
            if (id != pick.PickID)
            {
                return BadRequest();
            }

            _context.Entry(pick).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PickExists(id))
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

        // POST: api/Picks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pick>> PostPick(Pick pick)
        {
          if (_context.Picks == null)
          {
              return Problem("Entity set 'PicksContext.Picks'  is null.");
          }
            _context.Picks.Add(pick);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPick", new { id = pick.PickID }, pick);
        }

        // DELETE: api/Picks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePick(int id)
        {
            if (_context.Picks == null)
            {
                return NotFound();
            }
            var pick = await _context.Picks.FindAsync(id);
            if (pick == null)
            {
                return NotFound();
            }

            _context.Picks.Remove(pick);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PickExists(int id)
        {
            return (_context.Picks?.Any(e => e.PickID == id)).GetValueOrDefault();
        }
    }
}
