using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket_DataLayer.Entities.Users;

namespace WebMarket_CoreLayer.DTOs.Users
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public UserType Role { get; set; }
        public Gender Gender { get; set; }
        public DateTime RiesterDate { get; set; }

    }

    public class UserRegisterDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserType Role { get; set; }
        public Gender Gender { get; set; }
    }
    
    public class UserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
