using Travel.Dto;
using Travel.Dto.Trip;

namespace Travel.Bl.Plans
{
    public interface IPlans
    {
        public ResponseModel AddPlan(PlansDto planDto);
        public ResponseModel UpdatePlan(PlansDto planDto,int planId);
        public ResponseModel ListPlans();
        public ResponseModel GetPlan(int id);
        public ResponseModel ActivatePlan(int planId);
        public ResponseModel DeactivatePlan(int planId);

    }
}
