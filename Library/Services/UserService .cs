using Library.DTOs;
using Library.IRepository;
using System.Security.Claims;
using System.Text;
using Library.IServices;
using Library.Model;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace Library.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _Repository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _Repository = userRepository;
            _configuration = configuration;
        }

       

        public async Task<User> RegisterAsync(RegisterUserDto dto)
        {
            if (dto.RoleId != Guid.Parse("c56a4180-65aa-42ec-a945-5fd21dec0538") && dto.RoleId != Guid.Parse("c56a4180-65aa-42ec-a945-5fd21dec0545"))
                throw new Exception("Invalid role selected.");

            var existing = (await _Repository.GetAllAsync())
                           .FirstOrDefault(u => u.Email == dto.Email);

            if (existing != null)
                throw new Exception("User already exists.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var newUser = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = hashedPassword,
                Phone = dto.Phone,
                RoleId = dto.RoleId,
                Created = DateTime.UtcNow
            };

            return await _Repository.AddAsync(newUser);
        }


        public Task<string> LoginAsync(LoginUserDto dto)
        {
            return _Repository.LoginAsync(dto);
        }

    }
}
