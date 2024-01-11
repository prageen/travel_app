﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Dto.Trip
{
   public class LoginDto
    {
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
