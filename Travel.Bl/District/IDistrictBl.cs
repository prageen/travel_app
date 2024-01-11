using Travel.Dto;
using Travel.Dto.Trip;

namespace Travel.Bl.District
{
    public interface IDistrictBl
    {
        public ResponseModel AddDistrict(DistrictDto districtDto);
        public ResponseModel UpdateDistrict(DistrictDto districtDto, int districtId);
        public ResponseModel DeleteDistrict(int districtId);
    }
}
