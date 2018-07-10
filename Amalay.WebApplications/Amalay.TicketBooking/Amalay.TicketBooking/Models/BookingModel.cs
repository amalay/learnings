using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amalay.TicketBooking.Models
{
    //public class BookingModel
    //{
    //    [Required]
    //    [Display(Name = "No of seat")]
    //    public int Seats { get; set; }


    //    [Required]
    //    [Display(Name = "Plane")]
    //    public string SelectedPlaneId { get; set; }
        
    //    public IEnumerable<SelectListItem> Planes { get; set; }

    //    [Required]
    //    [Display(Name = "Seatings")]
    //    public string SelectedSeating { get; set; }
    //    public IEnumerable<SelectListItem> AvailableSeatings { get; set; }
    //}

    public class BookingModel
    {
        public List<SelectListItem> Planes { get; set; }

        [Required]
        [Display(Name = "Plane")]
        public int? SelectedPlaneId { get; set; }

        [Required]
        [Display(Name = "No of seat")]
        public int? Seats { get; set; }
    }
}