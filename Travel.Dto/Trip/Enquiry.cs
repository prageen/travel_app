using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Dto
{
    public  class Enquiry
    {
        [Key]
        public int EnquiryId { get; set; }

        public int EnquiryType { get; set; }

        public int Description { get; set; }

    }
}
