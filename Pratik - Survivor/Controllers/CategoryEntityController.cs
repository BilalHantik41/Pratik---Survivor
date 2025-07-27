// Controllers/CategoriesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pratik___Survivor.Context;
using Pratik___Survivor.Dtos;
using Pratik___Survivor.Entities;


namespace Pratik___Survivor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CategoriesController(SurvivorDbContext context)
            => _context = context;

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var list = await _context.Categories
                .Where(c => !c.IsDeleted)
                .Include(c => c.Competitors)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Competitors = c.Competitors
                                   .Where(x => !x.IsDeleted)
                                   .Select(x => new CompetitorDto
                                   {
                                       Id = x.Id,
                                       FirstName = x.FirstName,
                                       LastName = x.LastName,
                                       FullName = $"{x.FirstName} {x.LastName}",
                                       CategoryId = x.CategoryId,
                                       CategoryName = c.Name
                                   })
                                   .ToList()
                })
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/categories/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var dto = await _context.Categories
                .Where(c => c.Id == id && !c.IsDeleted)
                .Include(c => c.Competitors)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Competitors = c.Competitors
                                   .Where(x => !x.IsDeleted)
                                   .Select(x => new CompetitorDto
                                   {
                                       Id = x.Id,
                                       FirstName = x.FirstName,
                                       LastName = x.LastName,
                                       FullName = $"{x.FirstName} {x.LastName}",
                                       CategoryId = x.CategoryId,
                                       CategoryName = c.Name
                                   })
                                   .ToList()
                })
                .FirstOrDefaultAsync();

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        // POST: api/categories
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryDto input)
        {
            // Sadece Name bekliyoruz, geri kalan sistem tarafından atanıyor
            var entity = new CategoryEntity
            {
                Name = input.Name,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IsDeleted = false
            };

            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();

            // Geri döneceğimiz tam DTO
            var dto = new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Competitors = new()     // POST cevabında boş liste
            };

            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        // PUT: api/categories/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != input.Id)
                return BadRequest("URL’deki id, gövdedeki id ile eşleşmiyor.");

            var entity = await _context.Categories.FindAsync(id);
            if (entity == null || entity.IsDeleted)
                return NotFound();

            entity.Name = input.Name;
            entity.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/categories/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity == null || entity.IsDeleted)
                return NotFound();

            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
