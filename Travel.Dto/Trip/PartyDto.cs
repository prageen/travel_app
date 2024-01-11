using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Dto
{
  public  class PartyDto
    {
        public string PartyName { get; set; }
        [Required(ErrorMessage = "Phone Number Type is required")]
        public int PhoneNumber { get; set; }
    }
}
