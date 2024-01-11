using System;
using System.ComponentModel.DataAnnotations;

namespace Travel.Infrastructure
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string StateName { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
