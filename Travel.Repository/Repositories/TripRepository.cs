using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Repository.Repositories
{
   public class TripRepository : GenericRepository<TripDetails>, Interface.ITripRepository
    {
        public TripRepository(DataContext context) : base(context)
        {
        }
    }
}
