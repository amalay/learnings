using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amalay.TicketBooking.Models
{
    public class Plane
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Aeroplane Name")]
        public string Name { get; set; }

    }
}