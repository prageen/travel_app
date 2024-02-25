using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Dto.Trip
{
    public class PlansDto
    {
        [Key]
        public int PlanId { get; set; }
        [Required(ErrorMessage = "Planname shold not be empty")]
        public string PlanName { get; set; }
        public string PlanDesription { get; set; }
        [Required(ErrorMessage = "Plandays shold not be empty")]
        public int Days { get; set; }
        public int Status { get; set; } = 1;
    }
}
