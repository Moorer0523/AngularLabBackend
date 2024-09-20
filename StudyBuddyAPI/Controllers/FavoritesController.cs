using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyBuddyAPI.Data;
using StudyBuddyAPI.Models.Dto;
using StudyBuddyAPI.Models;
using StudyBuddyAPI.Models.DTO;
using StudyBuddyAPI.Models.Mapping;

namespace StudyBuddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly SbuddyDbContext _context;

        public FavoritesController(SbuddyDbContext context)
        {
            _context = context;
        }

        //// GET: api/Orders - Never needed to pull complete list of all favorite sets
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Favorites>>> GetFavorites()
        //{
        //    return await _context.Favorites.ToListAsync();
        //}

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorites>> GetFavorite(int id)
        {
            var favorites = await _context.Favorites.FindAsync(id);

            if (favorites == null)
            {
                return NotFound();
            }

            return favorites;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorites(int id, [FromBody] FavoritesDTO favoritesDTO)
        {
            try
            {
                Favorites currentFavorites = await _context.Favorites.FindAsync(id);
                if (currentFavorites == null)
                {
                    return NotFound();
                }

                //Need to redo mapping without automapper
                currentFavorites.UpdateFavorites(favoritesDTO);

                _context.Entry(currentFavorites).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Question>> PostOrder([FromBody] FavoritesDTO favoritesDTO)
        {
            //need to redo mapping without automapper
            Favorites favorites = favoritesDTO.ToFavorites();
            _context.Favorites.Add(favorites);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = favorites.Id }, favorites);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
