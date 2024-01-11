using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Dto
{
   public class LocationDto
    {
        [ForeignKey("DistrictID")]
        public District DistrictId { get; set; }
        public int District { get; set; }
        [Required(ErrorMessage = "Location Name is required")]
        public string LocationName { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
