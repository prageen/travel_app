using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;

namespace Travel.Bl.Vehicle
{
    public  interface IVehicleMasterBl
    {
        public ResponseModel AddVehicleCategory(VehicleMasterDto VehicleObj);

        public ResponseModel DeleteVehicleCategory(int vehicleId);

        public ResponseModel UpdateVehicleCategory(VehicleMasterDto VehicleObj, int vehicleId);

        public ResponseModel AddVehicle(VehicleDto VehicleObj);

        public ResponseModel DeleteVehicle(int vehicleId);

        public ResponseModel UpdateVehicle(VehicleDto VehicleObj, int vehicleId);

    }
}
