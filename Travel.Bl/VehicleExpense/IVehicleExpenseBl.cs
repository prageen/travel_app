using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;
using Travel.Dto.Trip;

namespace Travel.Bl.VehicleExpense
{
    public interface IVehicleExpenseBl
    {
        public ResponseModel AddVehicleExpense(VehicleExpenceDto vehicleExpenceDto);

        public ResponseModel DeleteVehicleExpense(int tripExpenceId);

        public ResponseModel UpdateVehicleExpense(VehicleExpenceDto vehicleExpenceDto, int vehicleId);
    }
}
