using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Repository.Repositories
{
 public   class TermsRepository : GenericRepository<Terms>, Interface.ITermsRepository
    {
        public TermsRepository(DataContext context) : base(context)
        {
        }
    }
}
