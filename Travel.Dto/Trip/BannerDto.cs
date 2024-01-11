using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Dto.Trip
{
   public class BannerDto
    {
        public byte[] BannerImage { get; set; }

        public DateTime BannerCreateDate { get; set; }
        public DateTime BannerUpdateDate { get; set; }
    }
}
