using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;
using Travel.Dto.Trip;
using Travel.Repository.Interface;

namespace Travel.Bl.Registration
{
    public class RegistrationBl : IRegistration
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public RegistrationBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ResponseModel ActivateRegistration(int registrationId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var Registration = _unitOfWork.Registration.GetById(registrationId);
                if (Registration.RegistrationId >= 0)
                {
                    Registration.Status = 1;
                    _unitOfWork.Registration.Update(Registration);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Registration Activated";
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
                    response.Message = "Plan doesnot exisst. Try with a valid one";
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

        public ResponseModel AddRegistration(RegistrationDto registrationDto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                registrationDto.Status= 1;
                 UsersDto usersDto = new UsersDto
                 {
                     CreatedDate = DateTime.Now,
                     LocationId = registrationDto.LocationId,
                     Password = registrationDto.Passowrd,
                     PhoneNumber = registrationDto.Phonenumber,
                     Status = registrationDto.Status,
                     UserType = registrationDto.UserType,
                 };

                var usersObject = _mapper.Map<UsersDto, Infrastructure.Users>(usersDto);
                _unitOfWork.Users.Add(usersObject);
                _unitOfWork.Complete();
                registrationDto.UsersId = usersObject.UsersId;

                registrationDto.AddedOn = DateTime.Now;

                var registrationObject = _mapper.Map<RegistrationDto, Infrastructure.Registration>(registrationDto);

                _unitOfWork.Registration.Add(registrationObject);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "Registration  Added";
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

        public ResponseModel DeactivateRegistration(int registrationId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var Registration = _unitOfWork.Registration.GetById(registrationId);
                if (Registration.RegistrationId >= 0)
                {
                    Registration.Status = 2;
                    _unitOfWork.Registration.Update(Registration);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Registration DeActivated";
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
                    response.Message = "Plan doesnot exisst. Try with a valid one";
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

        public ResponseModel GetRegistration(int id)
        {
            ResponseModel response = new ResponseModel();
            var Registration = _unitOfWork.Registration.GetById(id);
            response.Message = Registration;
            response.Status = "Success";
            return response;
        }

        public ResponseModel ListRegistration()
        {
            ResponseModel response = new ResponseModel();
            var Registrations = _unitOfWork.Registration.GetAll().Where(r=>r.Status==1).ToList();
            response.Message = Registrations;
            response.Status = "Success";
            return response;
        }

        public ResponseModel UpdateRegistration(RegistrationDto registrationDto, int registrationId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var Registration = _unitOfWork.Registration.GetById(registrationId);
                if (Registration.RegistrationId >= 0)
                {
                    Registration.DistrictId = registrationDto.DistrictId;
                    Registration.LocationId = registrationDto.LocationId;
                    Registration.StateId = registrationDto.StateId;
                    Registration.UpdatedOn = DateTime.Now;
                    Registration.BrandName = registrationDto.BrandName;
                    Registration.PlanId = registrationDto.PlansId;
                    Registration.TotalVehicles = registrationDto.TotalVehicles;

                    Registration.Status = 1;

                    _unitOfWork.Registration.Update(Registration);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Registration Updated";
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
