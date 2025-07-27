namespace Pratik___Survivor.Entities
{
    public class CategoryEntity: BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<CompetitorEntity> Competitors { get; set; }
    }
}
