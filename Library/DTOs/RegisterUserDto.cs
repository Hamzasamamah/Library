﻿namespace Library.DTOs
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  
        public string Phone { get; set; }
        public Guid RoleId { get; set; } 
    }

}
