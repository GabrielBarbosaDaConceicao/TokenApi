using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using TokenApi.Data;
using Microsoft.AspNetCore.Authorization;

namespace TokenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BreedsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Breeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breed>>> GetBreeds()
        {
          if (_context.Breeds == null)
          {
              return NotFound();
          }
            return await _context.Breeds.ToListAsync();
        }

        // GET: api/Breeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Breed>> GetBreed(int id)
        {
          if (_context.Breeds == null)
          {
              return NotFound();
          }
            var breed = await _context.Breeds.FindAsync(id);

            if (breed == null)
            {
                return NotFound();
            }

            return breed;
        }

        [Authorize]
        // PUT: api/Breeds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreed(int id, Breed breed)
        {
            if (id != breed.BreedId)
            {
                return BadRequest();
            }

            _context.Entry(breed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedExists(id))
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

        [Authorize]
        // POST: api/Breeds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Breed>> PostBreed(Breed breed)
        {
          if (_context.Breeds == null)
          {
              return Problem("Entity set 'ApplicationContext.Breeds'  is null.");
          }
            _context.Breeds.Add(breed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBreed", new { id = breed.BreedId }, breed);
        }

        [Authorize]
        // DELETE: api/Breeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed(int id)
        {
            if (_context.Breeds == null)
            {
                return NotFound();
            }
            var breed = await _context.Breeds.FindAsync(id);
            if (breed == null)
            {
                return NotFound();
            }

            _context.Breeds.Remove(breed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreedExists(int id)
        {
            return (_context.Breeds?.Any(e => e.BreedId == id)).GetValueOrDefault();
        }
    }
}
