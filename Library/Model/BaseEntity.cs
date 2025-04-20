namespace Library.Model
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
