using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Dto.Trip
{
    public class StateDto
    {
        [Required(ErrorMessage = "State is required")]
        public string StateName { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
