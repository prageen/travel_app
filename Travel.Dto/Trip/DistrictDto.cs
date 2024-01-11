using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Dto.Trip
{
    public class DistrictDto
    {
        [ForeignKey("StateId")]
        public State StateId { get; set; }
        public int State {  get; set; }
        [Required(ErrorMessage = "District Name is required")]
        public string DistrictName { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
