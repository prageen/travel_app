using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Repository.Repositories
{
   public class LocationRepository : GenericRepository<Location>, Interface.ILocationRepository
    {
        public LocationRepository(DataContext context) : base(context)
        {
        }
    }
}
