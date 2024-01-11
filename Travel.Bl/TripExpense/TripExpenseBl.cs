using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;
using Travel.Dto.Trip;
using Travel.Infrastructure;
using Travel.Infrastructure.Trip;
using Travel.Repository.Interface;

namespace Travel.Bl.TripExpense
{
    public class TripExpenseBl : ITripExpenseBl
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public TripExpenseBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ResponseModel AddTripExpense(TripExpenceDto TripExpenceDto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var TripExpenceObject = _mapper.Map<TripExpenceDto, TripExpence>(TripExpenceDto);
                _unitOfWork.TripExpence.Add(TripExpenceObject);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "Trip Expense Added";
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

        public ResponseModel DeleteTripExpense(int tripExpenceId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var tripExpenceMaster = _unitOfWork.TripExpence.GetById(tripExpenceId);
                if (tripExpenceMaster.TripExpenceExpenceId >= 0)
                {
                    _unitOfWork.TripExpence.Remove(tripExpenceMaster);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Vehicle" + tripExpenceId + "Deleted";
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

        public ResponseModel UpdateTripExpense(TripExpenceDto TripExpenceDto, int vehicleId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var tripExpenceMaster = _unitOfWork.TripExpence.GetById(vehicleId);
                if (tripExpenceMaster.TripExpenceExpenceId >= 0)
                {
                    tripExpenceMaster.TripExpenceExpenceId = tripExpenceMaster.TripExpenceExpenceId;
                    tripExpenceMaster.Description = TripExpenceDto.Description;
                    _unitOfWork.TripExpence.Update(tripExpenceMaster);
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


        public ResponseModel AddBanner(BannerDto bannerDto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var BannerDtoObject = _mapper.Map<BannerDto, Banner>(bannerDto);
                _unitOfWork.Banner.Add(BannerDtoObject);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "Banner Added";
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

        public ResponseModel UpdateBanner(BannerDto bannerDto,int bannerId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var banner = _unitOfWork.Banner.GetById(bannerId);
                if (banner.BannerId >= 0)
                {
                    banner.BannerImage = bannerDto.BannerImage;
                    _unitOfWork.Banner.Update(banner);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Banner Updated";
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
                    response.Message = "banner doesnot exist. Try with a valid one";
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

        public ResponseModel DeleteBanner(int bannerId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var banner = _unitOfWork.Banner.GetById(bannerId);
                if (banner.BannerId >= 0)
                {
                    _unitOfWork.Banner.Remove(banner);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Banner" + banner.BannerId + "Deleted";
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
    }
}
