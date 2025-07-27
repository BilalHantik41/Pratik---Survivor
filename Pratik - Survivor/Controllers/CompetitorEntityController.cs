using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pratik___Survivor.Context;
using Pratik___Survivor.Entities;
using static Pratik___Survivor.Context.SurvivorDbContext;


namespace Pratik___Survivor.Controllers
{
   
        [ApiController]
        [Route("api/competitors")]
        public class CompetitorEntityController : ControllerBase
        {
            private readonly SurvivorDbContext _context;
            public CompetitorEntityController(SurvivorDbContext context) => _context = context;

            [HttpGet]
            public async Task<IActionResult> GetAll() =>
                Ok(await _context.Competitors.Include(c => c.Category).ToListAsync());

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var competitor = await _context.Competitors.FindAsync(id);
                return competitor == null ? NotFound() : Ok(competitor);
            }

            [HttpGet("categories/{categoryId}")]
            public async Task<IActionResult> GetByCategory(int categoryId)
            {
                var competitors = await _context.Competitors
                    .Where(c => c.CategoryId == categoryId).ToListAsync();
                return Ok(competitors);
            }

            [HttpPost]
            public async Task<IActionResult> Create(CompetitorEntity competitor)
            {
                competitor.CreatedDate = DateTime.UtcNow;
                competitor.ModifiedDate = DateTime.UtcNow;
                competitor.IsDeleted = false;

                _context.Competitors.Add(competitor);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = competitor.Id }, competitor);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, CompetitorEntity updated)
            {
                var competitor = await _context.Competitors.FindAsync(id);
                if (competitor == null) return NotFound();

                competitor.FirstName = updated.FirstName;
                competitor.LastName = updated.LastName;
                competitor.CategoryId = updated.CategoryId;
                competitor.ModifiedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var competitor = await _context.Competitors.FindAsync(id);
                if (competitor == null) return NotFound();

                _context.Competitors.Remove(competitor);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }

