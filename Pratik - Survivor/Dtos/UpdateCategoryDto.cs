using System.ComponentModel.DataAnnotations;

namespace Pratik___Survivor.Dtos
{
    public class UpdateCategoryDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
    }
}
