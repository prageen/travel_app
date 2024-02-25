using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Infrastructure
{
    public class Plans
    {
        [Key]
        public int PlanId { get; set; }
        [Required(ErrorMessage ="Planname shold not be empty")]
        public string PlanName { get; set; }
        public string PlanDesription { get; set; }
        [Required(ErrorMessage = "Plandays shold not be empty")]
        public int Days { get; set; }
        public int Status { get; set; } = 1;

    }
}
