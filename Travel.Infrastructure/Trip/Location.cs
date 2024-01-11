using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure.Trip;

namespace Travel.Infrastructure
{
   public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [ForeignKey("DistrictId")]
        public District DistrictID { get; set; }
        [Required(ErrorMessage = "Vehicle Type is required")]
        public string LocationName { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
