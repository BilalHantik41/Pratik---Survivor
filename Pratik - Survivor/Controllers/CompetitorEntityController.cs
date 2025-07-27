// Controllers/CompetitorsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pratik___Survivor.Context;
using Pratik___Survivor.Dtos;
using Pratik___Survivor.Entities;


namespace Pratik___Survivor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitorsController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CompetitorsController(SurvivorDbContext context)
            => _context = context;

        // GET: api/competitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitorDto>>> GetAll()
        {
            var list = await _context.Competitors
                .Where(c => !c.IsDeleted)
                .Include(c => c.Category)
                .Select(c => new CompetitorDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    FullName = $"{c.FirstName} {c.LastName}",
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category!.Name
                })
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/competitors/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CompetitorDto>> GetById(int id)
        {
            var dto = await _context.Competitors
                .Where(c => c.Id == id && !c.IsDeleted)
                .Include(c => c.Category)
                .Select(c => new CompetitorDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    FullName = $"{c.FirstName} {c.LastName}",
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category!.Name
                })
                .FirstOrDefaultAsync();

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        // GET: api/competitors/categories/{categoryId}
        [HttpGet("categories/{categoryId:int}")]
        public async Task<ActionResult<IEnumerable<CompetitorDto>>> GetByCategory(int categoryId)
        {
            var list = await _context.Competitors
                .Where(c => c.CategoryId == categoryId && !c.IsDeleted)
                .Include(c => c.Category)
                .Select(c => new CompetitorDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    FullName = $"{c.FirstName} {c.LastName}",
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category!.Name
                })
                .ToListAsync();

            return Ok(list);
        }

        // POST: api/competitors
        [HttpPost]
        public async Task<ActionResult<CompetitorDto>> Create([FromBody] CreateCompetitorDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new CompetitorEntity
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                CategoryId = input.CategoryId,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IsDeleted = false
            };

            _context.Competitors.Add(entity);
            await _context.SaveChangesAsync();

            // İlişkili Category’i yükle
            await _context.Entry(entity).Reference(c => c.Category).LoadAsync();

            // Çıktı DTO’su oluştur
            var dto = new CompetitorDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                FullName = $"{entity.FirstName} {entity.LastName}",
                CategoryId = entity.CategoryId,
                CategoryName = entity.Category!.Name
            };

            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }


        // PUT: api/competitors/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCompetitorDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != input.Id)
                return BadRequest("URL’deki id, gövdedeki id ile eşleşmiyor.");

            // Geçerli kategori kontrolü
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == input.CategoryId && !c.IsDeleted);
            if (category == null)
                return BadRequest($"CategoryId = {input.CategoryId} geçersiz veya silinmiş.");

            var entity = await _context.Competitors.FindAsync(id);
            if (entity == null || entity.IsDeleted)
                return NotFound();

            // Alanları güncelle
            entity.FirstName = input.FirstName;
            entity.LastName = input.LastName;
            entity.CategoryId = input.CategoryId;
            entity.ModifiedDate = DateTime.UtcNow;

            // Eğer DB'de FullName tutuluyorsa:
            // entity.FullName = $"{input.FirstName} {input.LastName}";

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/competitors/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Competitors.FindAsync(id);
            if (entity == null || entity.IsDeleted)
                return NotFound();

            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
