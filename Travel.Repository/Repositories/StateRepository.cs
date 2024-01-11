using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;
using Travel.Infrastructure.Trip;

namespace Travel.Repository.Repositories
{
    public class StateRepository : GenericRepository<State>, Interface.IStateRepository
    {
        public StateRepository(DataContext context) : base(context)
        {
        }
    }
}
