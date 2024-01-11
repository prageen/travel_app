using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;
using Travel.Repository.Interface;

namespace Travel.Bl.Party
{
    public class PartyBl : IPartyBl
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public PartyBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        ResponseModel IPartyBl.AddParty(PartyDto partyObj)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var partyObject = _mapper.Map<PartyDto, Infrastructure.Party>(partyObj);
                _unitOfWork.Party.Add(partyObject);
                var result = _unitOfWork.Complete();
                if (result == 1)
                {
                    response.Message = "Party Added";
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

        ResponseModel IPartyBl.DeleteParty(int vehicleId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var partyMaster = _unitOfWork.Party.GetById(vehicleId);
                if (partyMaster.PartyId >= 0)
                {
                    _unitOfWork.Party.Remove(partyMaster);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Party" + vehicleId + "Deleted";
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

        ResponseModel IPartyBl.UpdateParty(PartyDto partyObj, int partyId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var partyMaster = _unitOfWork.Party.GetById(partyId);
                if (partyMaster.PartyId >= 0)
                {
                    partyMaster.PartyName = partyObj.PartyName;
                    partyMaster.PhoneNumber = partyObj.PhoneNumber;
                    _unitOfWork.Party.Update(partyMaster);
                    var result = _unitOfWork.Complete();
                    if (result == 1)
                    {
                        response.Message = "Party Updated";
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
                    response.Message = "Party doesnot exisst. Try with a valid one";
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
