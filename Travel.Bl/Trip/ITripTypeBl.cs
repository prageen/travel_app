using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;

namespace Travel.Bl.Trip
{
    public interface ITripTypeBl
    {
        public ResponseModel AddTripType(TripCategoryDto tripCategoryDto);

        public ResponseModel DeleteTripType(int vehicleId);

        public ResponseModel UpdateTripType(TripCategoryDto tripCategoryDto, int vehicleId);

    }
}
