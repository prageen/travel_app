using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;
using Travel.Repository.Repositories;

namespace Travel.Repository.Interface
{
    public interface IEnquiryRepository : IGenericRepository<Enquiry>
    {
    }
}
