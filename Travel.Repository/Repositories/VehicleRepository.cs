using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Repository.Repositories
{
   public class VehicleRepository : GenericRepository<Vehicle>, Interface.IVehicleRepository
    {
        public VehicleRepository(DataContext context) : base(context)
        {
        }
    }
}
