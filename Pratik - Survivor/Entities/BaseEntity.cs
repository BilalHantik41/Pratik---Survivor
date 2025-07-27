namespace Pratik___Survivor.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = new DateTime(2024, 1, 1, 10, 0, 0);
            ModifiedDate = new DateTime(2024, 1, 1, 10, 0, 0);
        }
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }
        

    }
}
