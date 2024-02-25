using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Dto.Trip
{
    public class RegistrationDto
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
        [ForeignKey("PlansId")]
        public int PlansId { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int Status { get; set; }
    }
}
