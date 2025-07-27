using System.ComponentModel.DataAnnotations.Schema;

namespace Pratik___Survivor.Entities
{
    public class CompetitorEntity : BaseEntity
    {
       
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        [NotMapped]                // EF Core artık tabloya kolon eklemez
        public string FullName => $"{FirstName} {LastName}";

        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = default!;
        
        
    }
}
