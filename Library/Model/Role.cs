
namespace Library.Model
{
    public class Role : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
     

        public ICollection<User> Users { get; set; } =new List<User>();
    }
}
