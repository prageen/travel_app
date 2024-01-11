﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Repository.Repositories
{
   public class TripExpenceRepository : GenericRepository<TripExpence>, Interface.ITripExpenceRepository
    {
        public TripExpenceRepository(DataContext context) : base(context)
        {
        }
    }
}
