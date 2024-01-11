using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;

namespace Travel.Bl.Driver_details
{
    public interface IDriverBl
    {
        public ResponseModel AddDriver(DriverDto driverDto);

        public ResponseModel DeleteDriver(int vehicleId);

        public ResponseModel UpdateDriver(DriverDto driverDto, int vehicleId);

    }
}
