using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Repository.Repositories
{
   public class VehicleMasterRepository : GenericRepository<VehicleMaster>, Interface.IVehicleMasterRepository
    {
        public VehicleMasterRepository(DataContext context) : base(context)
        {
        }
    }
}
