using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;
using Travel.Dto.Trip;
using Travel.Repository.Interface;

namespace Travel.Bl.Plans
{
    public class PlansBl : IPlans
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public PlansBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ResponseModel ActivatePlan(int planId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var Plan = _unitOfWork.Plans.GetById(planId);
                if (Plan.PlanId >= 0)
                {
                    Plan.Status = 1;
                    _unitOfWork.Plans.Update(Plan);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Plans Activated";
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

        public ResponseModel AddPlan(PlansDto planDto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var planObject = _mapper.Map<PlansDto, Infrastructure.Plans>(planDto);

                _unitOfWork.Plans.Add(planObject);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "Plan  Added";
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

        public ResponseModel DeactivatePlan(int planId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var Plan = _unitOfWork.Plans.GetById(planId);
                if (Plan.PlanId >= 0)
                {
                    Plan.Status = 2;
                    _unitOfWork.Plans.Update(Plan);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Plans Deleted";
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

        public ResponseModel GetPlan(int id)
        {
            ResponseModel response = new ResponseModel();
            var Plan = _unitOfWork.Plans.GetById(id);
            response.Message = Plan;
            return response;
        }

        public ResponseModel ListPlans()
        {
            ResponseModel response = new ResponseModel();
            var Plans = _unitOfWork.Plans.GetAll();
            response.Message = Plans;
            return response;
        }

        public ResponseModel UpdatePlan(PlansDto planDto, int planId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var Plan = _unitOfWork.Plans.GetById(planId);
                if (Plan.PlanId >= 0)
                {
                    Plan.PlanName = planDto.PlanName;
                    Plan.PlanDesription = planDto.PlanDesription;
                    Plan.Days = planDto.Days;
                    Plan.Status = 1;

                    _unitOfWork.Plans.Update(Plan);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Plan Updated";
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

