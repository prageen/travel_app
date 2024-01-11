using AutoMapper;
using System;
using Travel.Dto;
using Travel.Dto.Trip;
using Travel.Repository.Interface;

namespace Travel.Bl.District
{
    public class DistrictBl : IDistrictBl
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public DistrictBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ResponseModel AddDistrict(DistrictDto districtDto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var district = _mapper.Map<DistrictDto, Infrastructure.District>(districtDto);
                _unitOfWork.District.Add(district);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "District Added";
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

        public ResponseModel DeleteDistrict(int districtId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var district = _unitOfWork.District.GetById(districtId);
                if (district.DistrictId >= 0)
                {
                    _unitOfWork.District.Remove(district);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "District" + districtId + "Deleted";
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

        public ResponseModel UpdateDistrict(DistrictDto districtDto, int districtId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var district = _unitOfWork.District.GetById(districtId);
                if (district.DistrictId >= 0)
                {
                    district.DistrictId = districtId;
                    district.DistrictName = districtDto.DistrictName;
                    district.StateID = districtDto.StateId;
                    district.ReturnDate = districtDto.ReturnDate;
                    district.ReturnTime = districtDto.ReturnTime;

                    _unitOfWork.District.Update(district);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "District Updated";
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
                    response.Message = "District doesnot exist. Try with a valid one";
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
