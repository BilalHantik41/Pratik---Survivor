using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pratik___Survivor.Entities;
using Pratik___Survivor.Context;


namespace Pratik___Survivor.Controllers
{
   
        [ApiController]
        [Route("api/categories")]
        public class CategoryEntityController : ControllerBase
        {
            private readonly SurvivorDbContext _context;
            public CategoryEntityController(SurvivorDbContext context) => _context = context;

            [HttpGet]
            public async Task<IActionResult> GetAll() => Ok(await _context.Categories.ToListAsync());

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var category = await _context.Categories.FindAsync(id);
                return category == null ? NotFound() : Ok(category);
            }

            [HttpPost]
            public async Task<IActionResult> Create(CategoryEntity category)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, CategoryEntity updated)
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null) return NotFound();
                category.Name = updated.Name;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null) return NotFound();
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
