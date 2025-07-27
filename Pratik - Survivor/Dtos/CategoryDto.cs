namespace Pratik___Survivor.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CompetitorDto> Competitors { get; set; }
    }
}
