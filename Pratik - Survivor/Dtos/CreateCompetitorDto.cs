using System.ComponentModel.DataAnnotations;

namespace Pratik___Survivor.Dtos
{
    public class CreateCompetitorDto
    {
        [Required]
        public string FirstName { get; set; } = default!;

        [Required]
        public string LastName { get; set; } = default!;

        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int Id { get; set; }

    }
}
