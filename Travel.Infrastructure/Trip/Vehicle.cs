using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Infrastructure
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "Model is required")]
        public string Name { get; set; }

        [ForeignKey("VehicleMasterId")]
        public VehicleMaster VehicleTypeId { get; set; }

        public byte[] PollutionCertificate { get; set; }

        public DateTime PollutionStartDate { get; set; }

        public DateTime PollutionEndDate { get; set; }

        public byte[] PermitCertificate { get; set; }

        public DateTime PermitStartDate { get; set; }

        public DateTime PermitEndDate { get; set; }

        public byte[] Tax { get; set; }

        public DateTime TaxStartDate { get; set; }

        public DateTime TaxEndDate { get; set; }

        public byte[] Insurance { get; set; }

        public DateTime InsuranceStartDate { get; set; }

        public DateTime InsuranceEndDate { get; set; }

        [ForeignKey("LocationId")]
        public Location LocationIdentification { get; set; }

        [ForeignKey("DriverId")]
        public Driver DriverIdentification { get; set; }

        public string VehicleRegNo { get; set; }

    }
}
