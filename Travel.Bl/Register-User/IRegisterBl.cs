using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;
using Travel.Infrastructure;

namespace Travel.Bl.Register
{
   public interface IRegisterBl
    {
        public  Task<ResponseModel> Signup(RegisterDto appUserDto);

        //public Task<User> Login(string username, string password);

        public Task<dynamic> SignIn(string phoneNumber, string password);
    }
}
