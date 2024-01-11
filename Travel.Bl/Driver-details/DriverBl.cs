using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;
using Travel.Infrastructure;
using Travel.Repository.Interface;

namespace Travel.Bl.Driver_details
{
    public class DriverBl : IDriverBl
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public DriverBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
     
        public ResponseModel AddDriver(DriverDto driverDto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var driverObject = _mapper.Map<DriverDto, Driver>(driverDto);
                _unitOfWork.Driver.Add(driverObject);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "Driver Added";
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

        public ResponseModel DeleteDriver(int driverId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var driverMaster = _unitOfWork.Driver.GetById(driverId);
                if (driverMaster.DriverId >= 0)
                {
                    _unitOfWork.Driver.Remove(driverMaster);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Driver" + driverId + "Deleted";
                        response.Status = "Success";
                    }
                    else
                    {
                        response.Message = "Please try later, Some error occured";
                        response.Status = "Error";
                    }
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

        public ResponseModel UpdateDriver(DriverDto driverDto, int driverId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var driverMaster = _unitOfWork.Driver.GetById(driverId);
                if (driverMaster.DriverId >= 0)
                {
                    driverMaster.DriverId = driverDto.DriverId;
                    driverMaster.Name = driverDto.Name;
                    driverMaster.Phone = driverDto.Phone;
                    driverMaster.AlternateContact = driverDto.AlternateContact;

                    driverMaster.LicenceNo = driverDto.LicenceNo;
                    driverMaster.ValidFrom = driverDto.ValidFrom;
                    driverMaster.ValidTo = driverDto.ValidTo;
                    driverMaster.FrontCopy = driverDto?.FrontCopy;
                    driverMaster.BackCopy = driverDto?.BackCopy;
                    _unitOfWork.Driver.Update(driverMaster);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "driverMaster Updated";
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
                    response.Message = "Driver doesnot exisst. Try with a valid one";
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
