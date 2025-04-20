using Library.DTOs;
using Library.Model;

namespace Library.IServices
{
    public interface IUserService
    {
        Task<User> RegisterAsync(RegisterUserDto dto);
        Task<string> LoginAsync(LoginUserDto dto);
    }
}
