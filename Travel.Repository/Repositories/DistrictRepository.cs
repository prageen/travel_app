using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;
using Travel.Infrastructure.Trip;

namespace Travel.Repository.Repositories
{
    public class DistrictRepository : GenericRepository<District>, Interface.IDistrictRepository
    {
        public DistrictRepository(DataContext context) : base(context)
        {
        }
    }
}
