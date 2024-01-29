using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;
using Travel.Dto.Trip;

namespace Travel.Bl.Users
{
    public interface IUsersBl
    {
        public ResponseModel AddUsers(UsersDto usersDto);
        public ResponseModel UpdateUsers(UsersDto usersDto, int usersId);
        public ResponseModel DeleteUsers(int usersId);
        public ResponseModel ActivateUsers(int usersId);

    }
}
