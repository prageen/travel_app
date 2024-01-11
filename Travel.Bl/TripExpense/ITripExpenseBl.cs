using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;
using Travel.Dto.Trip;

namespace Travel.Bl.TripExpense
{
    public interface ITripExpenseBl
    {
        public ResponseModel AddTripExpense(TripExpenceDto TripExpenceDto);

        public ResponseModel DeleteTripExpense(int tripExpenceId);

        public ResponseModel UpdateTripExpense(TripExpenceDto TripExpenceDto, int vehicleId);

        public ResponseModel AddBanner(BannerDto bannerDto);

        public ResponseModel UpdateBanner(BannerDto bannerDto, int bannerId);

        public ResponseModel DeleteBanner( int bannerId);
    }
}
