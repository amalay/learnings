using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Amalay.TicketBooking.Models
{
    public class Seating
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Plane")]
        public int PlaneId { get; set; }

        public int RowIndex { get; set; }

        public int ColumnIndex { get; set; }

        public bool IsBooked { get; set; }

        public virtual Plane Plane { get; set; }
    }    
}