﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Dto
{
    public class Terms
    {

        [Key]
        public int Id { get; set; }
        public string TermsAndConditions { get; set; }
    }
}
