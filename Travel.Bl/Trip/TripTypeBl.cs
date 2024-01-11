using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;
using Travel.Infrastructure;
using Travel.Repository.Interface;

namespace Travel.Bl.Trip
{
    public class TripTypeBl : ITripTypeBl
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public TripTypeBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ResponseModel AddTripType(TripCategoryDto tripCategoryDto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var tripCategory = _mapper.Map<TripCategoryDto, TripCategory>(tripCategoryDto);
                _unitOfWork.TripCategory.Add(tripCategory);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "Trip Category Added";
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

        public ResponseModel DeleteTripType(int tripId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var tripCategory = _unitOfWork.TripCategory.GetById(tripId);
                if (tripCategory.TripCategoryId >= 0)
                {
                    _unitOfWork.TripCategory.Remove(tripCategory);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Trip" + tripId + "Deleted";
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

        public ResponseModel UpdateTripType(TripCategoryDto tripCategoryDto, int vehicleId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var tripCategory = _unitOfWork.TripCategory.GetById(vehicleId);
                if (tripCategory.TripCategoryId >= 0)
                {
                    tripCategory.Category = tripCategoryDto.Category;
                    _unitOfWork.TripCategory.Update(tripCategory);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Trip Category Updated";
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
                    response.Message = "Trip Category doesnot exisst. Try with a valid one";
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
