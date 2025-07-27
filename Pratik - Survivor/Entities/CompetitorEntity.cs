namespace Pratik___Survivor.Entities
{
    public class CompetitorEntity : BaseEntity
    {
        public CompetitorEntity()
        {
             CreatedDate = DateTime.Now;
        }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string FullName { get; set; } = string.Join(" ", "FirstName", "LastName");

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        
    }
}
