
namespace Library.Model
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Guid RoleId { get; set; }
        

        
        public Role Role { get; set; }
    }
}
