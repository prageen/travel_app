using Travel.Dto;
using Travel.Dto.Trip;

namespace Travel.Bl.State
{
    public interface IStateBl
    {
        public ResponseModel AddState(StateDto stateDto); 
        public ResponseModel UpdateState(StateDto stateDto, int stateId);
        public ResponseModel DeleteState(int stateId);
    }
}
