using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;
using Travel.Repository.Interface;


namespace Travel.Repository.Repositories
{
    public class PlansRepository : GenericRepository<Plans>, IPlansRepository
    {
        public PlansRepository(DataContext context) : base(context)
        {
        }
    }
}
