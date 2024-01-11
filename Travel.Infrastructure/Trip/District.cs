using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Infrastructure
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        [ForeignKey("StateId")]
        public State StateID {  get; set; }
        [Required(ErrorMessage = "District Name is required")]
        public string DistrictName {  get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
