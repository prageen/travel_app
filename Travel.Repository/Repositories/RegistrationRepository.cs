using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;
using Travel.Repository.Interface;

namespace Travel.Repository.Repositories
{
    public class RegistrationRepository: GenericRepository<Registration>, IRegistrationRepository
    {
        public RegistrationRepository(DataContext context) : base(context)
        { 
        }
    }
}
