using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Repository.Repositories
{
   public class TripTypeRepository : GenericRepository<TripCategory>, Interface.ITripTypeRepository
    {
        public TripTypeRepository(DataContext context) : base(context)
        {
        }
    }
}
