using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket_DataLayer.Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Created { get; set; }= DateTime.Now;
        public UserType Role { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }
    }
    public enum UserType
    {
        Customer,
        Admin
    }
    public enum Gender
    {
        Male,
        Female
    }
}
