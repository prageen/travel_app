using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Repository.Repositories
{
  public  class EnquiryRepository : GenericRepository<Enquiry>, Interface.IEnquiryRepository
    {
        public EnquiryRepository(DataContext context) : base(context)
        {
        }
    }
}
