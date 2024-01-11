using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;
using Travel.Repository.Interface;

namespace Travel.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
            //AuthUser = new AuthenticationRepository(_context);
            Driver = new DriverRepository(_context);
            Enquiry = new EnquiryRepository(_context);
            Location = new LocationRepository(_context);
            Party = new PartyRepository(_context);
            Terms = new TermsRepository(_context);
            Trip = new TripRepository(_context);
            TripCategory = new TripTypeRepository(_context);
            VehicleMaster = new VehicleMasterRepository(_context);
            Vehicle = new VehicleRepository(_context);
            TripExpence = new TripExpenceRepository(_context);
            VehicleExpense = new VehicleExpenseRepository(_context);
            Banner = new BannerRepository(_context);
            State = new StateRepository(_context);
            District = new DistrictRepository(_context);

        }
        //public IAuthenticationRepository AuthUser { get; private set; }
        public IDriverRepository Driver { get; private set; }
        public IEnquiryRepository Enquiry { get; private set; }

        public ILocationRepository Location { get; private set; }

        public IPartyRepository Party { get; private set; }

        public ITermsRepository Terms { get; private set; }

        public ITripRepository Trip { get; private set; }

        public ITripTypeRepository TripCategory { get; private set; }

        public IVehicleMasterRepository VehicleMaster { get; private set; }

        public IVehicleRepository Vehicle { get; private set; }

        public ITripExpenceRepository TripExpence { get; private set; }

        public IVehicleExpenseRepository VehicleExpense { get; private set; }

        public IBannerRepository Banner { get; private set; }
        public IStateRepository State { get; private set; }
        public IDistrictRepository District { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
