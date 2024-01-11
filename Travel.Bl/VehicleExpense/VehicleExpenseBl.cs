using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;
using Travel.Dto.Trip;
using Travel.Infrastructure;
using Travel.Repository.Interface;

namespace Travel.Bl.VehicleExpense
{
    public class VehicleExpenseBl : IVehicleExpenseBl
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public VehicleExpenseBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ResponseModel AddVehicleExpense(VehicleExpenceDto vehicleExpenceDto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var VehicleExpenceObject = _mapper.Map<VehicleExpenceDto, VehicleExpence>(vehicleExpenceDto);
                _unitOfWork.VehicleExpense.Add(VehicleExpenceObject);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "Vehicle Expense Added";
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

        public ResponseModel DeleteVehicleExpense(int VehicleExpenceId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var VehicleExpenceMaster = _unitOfWork.VehicleExpense.GetById(VehicleExpenceId);
                if (VehicleExpenceMaster.VehicleExpenceId >= 0)
                {
                    _unitOfWork.VehicleExpense.Remove(VehicleExpenceMaster);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Vehicle" + VehicleExpenceId + "Deleted";
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

        public ResponseModel UpdateVehicleExpense(VehicleExpenceDto vehicleExpenceDto, int vehicleId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var VehicleExpenseMaster = _unitOfWork.VehicleExpense.GetById(vehicleId);
                if (VehicleExpenseMaster.VehicleExpenceId >= 0)
                {
                    VehicleExpenseMaster.VehicleExpenceId = VehicleExpenseMaster.VehicleExpenceId;
                    VehicleExpenseMaster.Description = vehicleExpenceDto.Description;
                    _unitOfWork.VehicleExpense.Update(VehicleExpenseMaster);
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
