using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amalay.FoodOrder.Models
{
    public class GuestViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string GuestAcct { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string GuestPassword { get; set; }

    }
}