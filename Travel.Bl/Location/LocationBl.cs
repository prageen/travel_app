using AutoMapper;
using System;
using Travel.Dto;
using Travel.Repository.Interface;

namespace Travel.Bl.Location
{
    public class LocationBl : ILocationBl
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public LocationBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ResponseModel AddLocation(LocationDto locationDto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var location = _mapper.Map<LocationDto, Infrastructure.Location>(locationDto);
                _unitOfWork.Location.Add(location);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "Location Added";
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

        public ResponseModel DeleteLocation(int locationId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var location = _unitOfWork.Location.GetById(locationId);
                if (location.LocationId >= 0)
                {
                    _unitOfWork.Location.Remove(location);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Location" + locationId + "Deleted";
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

        public ResponseModel UpdateLocation(LocationDto locationDto, int locationId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var location = _unitOfWork.Location.GetById(locationId);
                if (location.LocationId >= 0)
                {
                    location.LocationId = locationId;
                    location.DistrictID = locationDto.DistrictId;
                    location.LocationName = locationDto.LocationName;
                    location.ReturnDate = locationDto.ReturnDate;
                    location.ReturnTime = locationDto.ReturnTime;

                    _unitOfWork.Location.Update(location);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Location Updated";
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
                    response.Message = "Location doesnot exist. Try with a valid one";
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
