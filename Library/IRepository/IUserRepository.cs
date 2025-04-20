using Library.DTOs;
using Library.Model;

namespace Library.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<string> LoginAsync(LoginUserDto dto);
    }
}
