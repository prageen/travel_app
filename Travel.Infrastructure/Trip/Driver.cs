using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Infrastructure
{
   public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public int Phone { get; set; }

        public int AlternateContact { get; set; }

        [Required(ErrorMessage = "Licence No is required")]
        public string LicenceNo { get; set; }
        [Required(ErrorMessage = "Valid From is required")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Valid To is required")]
        public DateTime ValidTo { get; set; }

        public byte[] FrontCopy { get; set; }

        public byte[] BackCopy { get; set; }
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public Users Owner { get; set; }
    }
}
