using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Infrastructure
{
    public class VehicleMaster
    {
        [Key]
        public int VehicleMasterId { get; set; }
        [Required(ErrorMessage = "Vehicle Type is required")]
        public string VehicleType { get; set; }
        [Required(ErrorMessage = "Seat Capacity is required")]
        public string SeatCapacity { get; set; }
        public byte[]? icon { get; set; } = null;

    }
}
