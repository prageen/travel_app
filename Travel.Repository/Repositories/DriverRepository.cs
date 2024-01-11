using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Repository.Repositories
{
   public class DriverRepository : GenericRepository<Driver>, Interface.IDriverRepository
    {
        public DriverRepository(DataContext context) : base(context)
        {
        }
    }
}
