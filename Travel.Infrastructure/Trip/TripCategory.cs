using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Infrastructure
{
    public class TripCategory
    {
        [Key]
        public int TripCategoryId { get; set; }
        public string Category { get; set; }
    }
}
