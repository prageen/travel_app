using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Infrastructure
{
    public class Party
    {
        [Key]
        public int PartyId { get; set; }
        [Required(ErrorMessage = "Party Name Type is required")]
        public string PartyName { get; set; }
        [Required(ErrorMessage = "Phone Number Type is required")]
        public int PhoneNumber { get; set; }
    }
}
