using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlog_Core.Utilities;
using WebMarket_CoreLayer.DTOs.Users;
using WebMarket_CoreLayer.Utilities;
using WebMarket_DataLayer.Context;
using WebMarket_DataLayer.Entities.Users;

namespace WebMarket_CoreLayer.Servises.Users
{
    public interface IUserService
    {
        OperationResult Register(UserRegisterDto userDto);
        UserDto Login(UserLoginDto userLoginDto);
    }

    public class UserService : IUserService
    {
        private readonly WebMarketContext _context;

        public UserService(WebMarketContext context)
        {
            _context = context;
        }

        public UserDto Login(UserLoginDto userLoginDto)
        {
            var passwordHash =userLoginDto.Password.EncodeToMd5();
            var user = _context.users.FirstOrDefault(u=>u.UserName==userLoginDto.UserName&&u.Password==passwordHash);

            if(user==null)
                return null;

            var userDto=new UserDto()
            {
                UserName=user.UserName,
                Password=user.Password,
                Role=user.Role,
                Gender=user.Gender,
                FullName=user.FullName,
                UserId=user.Id,
                RiesterDate=user.Created
            };

            return userDto;
        }

        public OperationResult Register(UserRegisterDto userDto)
        {
            var UserNameIsExist = _context.users.Any(u => u.UserName == userDto.UserName);

            if (UserNameIsExist)
                return OperationResult.Error("UserNameIsExist");

            var HashCode =userDto.Password.EncodeToMd5();

            var user = new User() 
            { 
                UserName=userDto.UserName,
                FullName=userDto.FullName,
                Email=userDto.Email,
                PhoneNumber=userDto.PhoneNumber,
                Role=userDto.Role,
                IsActive=true,
                Gender=userDto.Gender,
                Password=HashCode,
                Created=DateTime.Now
            };
            _context.users.Add(user);
            return OperationResult.Success();
        }
    }
}
