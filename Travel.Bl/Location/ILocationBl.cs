using Travel.Dto;

namespace Travel.Bl.Location
{
    public interface ILocationBl
    {
        public ResponseModel AddLocation(LocationDto locationDto);
        public ResponseModel UpdateLocation(LocationDto locationDto, int locationId);
        public ResponseModel DeleteLocation(int locationId);
    }
}

