using AutoMapper;
using System;
using Travel.Dto;
using Travel.Infrastructure;
using Travel.Repository.Interface;

namespace Travel.Bl.Vehicle
{
    public class VehicleMasterBl : IVehicleMasterBl
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public VehicleMasterBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ResponseModel AddVehicleCategory(VehicleMasterDto VehicleObj)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var VehicleObject = _mapper.Map<VehicleMasterDto, VehicleMaster>(VehicleObj);
                _unitOfWork.VehicleMaster.Add(VehicleObject);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "Vehicle Added";
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

        public ResponseModel DeleteVehicleCategory(int vehicleId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var vehicleMaster = _unitOfWork.VehicleMaster.GetById(vehicleId);
                if (vehicleMaster.VehicleMasterId >= 0)
                {
                    _unitOfWork.VehicleMaster.Remove(vehicleMaster);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Vehicle" + vehicleId + "Deleted";
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

        public ResponseModel UpdateVehicleCategory(VehicleMasterDto VehicleObj, int vehicleId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var vehicleMaster = _unitOfWork.VehicleMaster.GetById(vehicleId);
                if (vehicleMaster.VehicleMasterId >= 0)
                {
                    vehicleMaster.VehicleMasterId = vehicleMaster.VehicleMasterId;
                    vehicleMaster.VehicleType = VehicleObj.VehicleType;
                    vehicleMaster.SeatCapacity = VehicleObj.SeatCapacity;
                    vehicleMaster.icon = VehicleObj?.icon;


                    _unitOfWork.VehicleMaster.Update(vehicleMaster);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Vehicle Updated";
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
                    response.Message = "Vehicle doesnot exisst. Try with a valid one";
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

        public ResponseModel AddVehicle(VehicleDto VehicleObj)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var VehicleObject = _mapper.Map<VehicleDto, Infrastructure.Vehicle>(VehicleObj);
                _unitOfWork.Vehicle.Add(VehicleObject);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "Vehicle Added";
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

        public ResponseModel DeleteVehicle(int vehicleId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var vehicleMaster = _unitOfWork.Vehicle.GetById(vehicleId);
                if (vehicleMaster.VehicleId >= 0)
                {
                    _unitOfWork.Vehicle.Remove(vehicleMaster);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Vehicle" + vehicleId + "Deleted";
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

        public ResponseModel UpdateVehicle(VehicleDto VehicleObj, int vehicleId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var vehicleMaster = _unitOfWork.Vehicle.GetById(vehicleId);
                if (vehicleMaster.VehicleId >= 0)
                {
                    vehicleMaster.VehicleId = vehicleMaster.VehicleId;
                    vehicleMaster.Name = VehicleObj.Name;
                    vehicleMaster.PollutionCertificate = VehicleObj?.PollutionCertificate;
                    vehicleMaster.PollutionStartDate = VehicleObj.PollutionStartDate;
                    vehicleMaster.PollutionEndDate = VehicleObj.PollutionEndDate;
                    vehicleMaster.PermitCertificate = VehicleObj?.PermitCertificate;
                    vehicleMaster.PollutionEndDate = VehicleObj.PermitStartDate;
                    vehicleMaster.PermitEndDate = VehicleObj.PermitEndDate;
                    vehicleMaster.Tax = VehicleObj?.Tax;
                    vehicleMaster.TaxStartDate = VehicleObj.TaxStartDate;
                    vehicleMaster.TaxEndDate = VehicleObj.TaxEndDate;
                    vehicleMaster.Insurance = VehicleObj?.Insurance;
                    vehicleMaster.InsuranceStartDate = VehicleObj.InsuranceStartDate;
                    vehicleMaster.InsuranceEndDate = VehicleObj.InsuranceEndDate;
                    vehicleMaster.VehicleRegNo = VehicleObj.VehicleRegNo;
                    _unitOfWork.Vehicle.Update(vehicleMaster);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Vehicle Updated";
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
                    response.Message = "Vehicle doesnot exisst. Try with a valid one";
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
