using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        //public IAuthenticationRepository AuthUser { get; }
        public IDriverRepository Driver { get; }
        public IEnquiryRepository Enquiry { get; }

        public ILocationRepository Location { get; }

        public IPartyRepository Party { get; }

        public ITermsRepository Terms { get; }

        public ITripRepository Trip { get; }

        public ITripTypeRepository TripCategory { get; }

        public IVehicleMasterRepository VehicleMaster { get; }

        public IVehicleRepository Vehicle { get; }

        public ITripExpenceRepository TripExpence { get; }

        public IVehicleExpenseRepository VehicleExpense { get; }

        public IBannerRepository Banner { get; }
        public IStateRepository State { get; }
        public IDistrictRepository District { get; }
        int Complete();
    }
}
