using AutoMapper;
using System;
using Travel.Dto;
using Travel.Dto.Trip;
using Travel.Repository.Interface;
using Travel.Infrastructure;

namespace Travel.Bl.State
{
    public class StateBl : IStateBl
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public StateBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ResponseModel AddState(StateDto stateDto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var stateObject = _mapper.Map<StateDto, Infrastructure.State>(stateDto);
                _unitOfWork.State.Add(stateObject);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "State Added";
                    response.Status = "Success";
                }
                else
                {
                    response.Message = "Please try later, Some error occured";
                    response.Status = "Error";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                response.Message = "Please try later, Some error occured";
                response.Status = "Error";
            }
            return response;
        }

        public ResponseModel DeleteState(int stateId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var state = _unitOfWork.State.GetById(stateId);
                if (state.StateId >= 0)
                {
                    _unitOfWork.State.Remove(state);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "State" + stateId + "Deleted";
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

        public ResponseModel UpdateState(StateDto stateDto, int stateId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var state = _unitOfWork.State.GetById(stateId);
                if (state.StateId >= 0)
                {
                    state.StateId = stateId;
                    state.StateName = stateDto.StateName;
                    state.ReturnDate = stateDto.ReturnDate;
                    state.ReturnTime = stateDto.ReturnTime;

                    _unitOfWork.State.Update(state);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "State Updated";
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
                    response.Message = "State doesnot exist. Try with a valid one";
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
