using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Infrastructure
{
   public class TripExpence
    {
        [Key]
        public int TripExpenceExpenceId { get; set; }
        public string Description { get; set; }
    }
}
