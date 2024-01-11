using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Infrastructure.Trip
{
   public class Banner
    {
        [Key]
        public int BannerId { get; set; }
        [Required(ErrorMessage = "Banner Image is required")]
        public byte[] BannerImage { get; set; }

        public DateTime BannerCreateDate { get; set; }
        public DateTime BannerUpdateDate { get; set; }
    }
}
