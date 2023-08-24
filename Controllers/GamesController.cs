using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_FB.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using API_FB.Models.Contexts;

namespace API_FB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesContext _context;

        public GamesController(GamesContext context)
        {
            _context = context;
        }

        // GET: api/Game
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
          if (_context.Games == null)
          {
              return NotFound();
          }
            return await _context.Games.ToListAsync();
        }

        // GET: api/Game/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGames(int id)
        {
          if (_context.Games == null)
          {
              return NotFound();
          }
            var games = await _context.Games.FindAsync(id);

            if (games == null)
            {
                return NotFound();
            }

            return games;
        }

        // GET: api/Games
        [HttpGet("/api/Games/Week={Week}")]
        public async Task<ActionResult<List<Game>>> GetGamesByWeek(int Week)
        {
            if (_context.Games == null)
            {
                return NotFound();
            }

            var games = await _context.Games.Where(i => i.Week == Week).ToListAsync();
            
            if (games == null)
            {
                return NotFound();
            }

            return games;  
        }

        // EXAMPLE OF MULTIPLE FIELDS BEING FILTERED IN QUERY!!!!
        // GET: api/Games
        [HttpGet("/api/Games/Week={Week}/HomeSpread={HomeSpread}")]
        public async Task<ActionResult<List<Game>>> GetGamesByWeekAndSpread(int Week, float HomeSpread)
        {
            if (_context.Games == null)
            {
                return NotFound();
            }

            var games = await _context.Games.Where(i => (i.Week == Week && i.HomeSpread == HomeSpread)).ToListAsync();

            if (games == null)
            {
                return NotFound();
            }

            return games;
        }

        // PUT: api/Game/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGames(int id, Game games)
        {
            if (id != games.GameID)
            {
                return BadRequest();
            }

            _context.Entry(games).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesExists(id))
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


        // POST: api/Game
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Game>> PostGames(Game games)
        {
          if (_context.Games == null)
          {
              return Problem("Entity set 'GamesContext.Games'  is null.");
          }
            _context.Games.Add(games);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGames", new { id = games.GameID }, games);
        }

        // DELETE: api/Game/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGames(int id)
        {
            if (_context.Games == null)
            {
                return NotFound();
            }
            var games = await _context.Games.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }

            _context.Games.Remove(games);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GamesExists(int id)
        {
            return (_context.Games?.Any(e => e.GameID == id)).GetValueOrDefault();
        }
    }
}
