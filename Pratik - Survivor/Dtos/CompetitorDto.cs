namespace Pratik___Survivor.Dtos
{
    public class CompetitorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        //public string FullName => string.Join(", ", FirstName, LastName);
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = default!;
    }
}
