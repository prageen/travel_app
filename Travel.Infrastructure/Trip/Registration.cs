using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Infrastructure
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }
        [ForeignKey("UsersId")]
        public int UsersId { get; set; }
        public string BrandName { get; set; }
        public int TotalVehicles { get; set; }
        [ForeignKey("StateId")]
        public int StateId { get; set; }
        [ForeignKey("DistrictId")]
        public int DistrictId { get; set; }
        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        [ForeignKey("PlanId")]
        public int PlanId { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int Status { get; set; }

    }
}
