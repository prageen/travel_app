using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;
using Travel.Dto.Trip;
using Travel.Repository.Interface;

namespace Travel.Bl.Users
{
    public class UsersBl : IUsersBl
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public UsersBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ResponseModel AddUsers(UsersDto usersDto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var usersObject = _mapper.Map<UsersDto, Infrastructure.Users>(usersDto);
                _unitOfWork.Users.Add(usersObject);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "Uses  Added";
                    response.Status = "Success";
                }
                else
                {
                    response.Message = "Please try later, Some error occured";
                    response.Status = "Error";
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                response.Message = "Please try later, Some error occured";
                response.Status = "Error";
            }
            return response;
        }

        public ResponseModel DeleteUsers(int usersId)
        {

            ResponseModel response = new ResponseModel();
            try
            {
                var User = _unitOfWork.Users.GetById(usersId);
                if (User.UsersId >= 0)
                {
                    
                    User.Status = 2;
                   
                    _unitOfWork.Users.Update(User);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "User Deleted";
                        response.Status = "Success";
                    }
                    else
                    {
                        response.Message = "Please try later, Some error occured";
                        response.Status = "Error";
                    }
                }
                else
                {
                    response.Message = "User doesnot exisst. Try with a valid one";
                    response.Status = "Error";
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                response.Message = "Please try later, Some error occured";
                response.Status = "Error";
            }
            return response;
        }
        public ResponseModel ActivateUsers(int usersId)
        {

            ResponseModel response = new ResponseModel();
            try
            {
                var User = _unitOfWork.Users.GetById(usersId);
                if (User.UsersId >= 0)
                {
                    User.Status = 1;
                    _unitOfWork.Users.Update(User);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "User Deleted";
                        response.Status = "Success";
                    }
                    else
                    {
                        response.Message = "Please try later, Some error occured";
                        response.Status = "Error";
                    }
                }
                else
                {
                    response.Message = "User doesnot exisst. Try with a valid one";
                    response.Status = "Error";
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                response.Message = "Please try later, Some error occured";
                response.Status = "Error";
            }
            return response;
        }

        public ResponseModel UpdateUsers(UsersDto usersDto, int usersId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var User = _unitOfWork.Users.GetById(usersId);
                if (User.UsersId  >= 0)
                {
                    User.LocationId = usersDto.LocationId;
                    User.Status = usersDto.Status;
                    User.CreatedDate = usersDto.CreatedDate;
                    User.BrandName=usersDto.BrandName;
                    User.Password=usersDto.Password;
                    User.PhoneNumber = usersDto.PhoneNumber;
                    User.UserType=usersDto.UserType;
                    _unitOfWork.Users.Update(User);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "User Updated";
                        response.Status = "Success";
                    }
                    else
                    {
                        response.Message = "Please try later, Some error occured";
                        response.Status = "Error";
                    }
                }
                else
                {
                    response.Message = "User doesnot exisst. Try with a valid one";
                    response.Status = "Error";
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                response.Message = "Please try later, Some error occured";
                response.Status = "Error";
            }
            return response;
        }
    }
}
