using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Repository.Repositories
{
   public class PartyRepository : GenericRepository<Party>, Interface.IPartyRepository
    {
        public PartyRepository(DataContext context) : base(context)
        {
        }
    }
}
