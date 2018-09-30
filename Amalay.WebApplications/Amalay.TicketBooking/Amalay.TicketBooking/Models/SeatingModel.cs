using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Amalay.TicketBooking.Models
{
    public class SeatingModel
    {
        public int SeatId { get; set; }

        public int PlaneId { get; set; }

        public int RowIndex { get; set; }

        public int ColumnIndex { get; set; }

        public int SeatLength { get; set; }

        //public List<string> SeatNames
        //{
        //    get
        //    {
        //        var seatName = new List<string>();

        //        for(var i = this.ColumnIndex; i < (this.ColumnIndex + this.SeatLength); i++)
        //        {
        //            seatName.Add(this.RowIndex + Utilities.Instance.SeatMapping[i]);
        //        }                

        //        return seatName;
        //    }
        //}

        public string SeatNames
        {
            get
            {
                var sb = new StringBuilder();

                for (var i = this.ColumnIndex; i < (this.ColumnIndex + this.SeatLength); i++)
                {
                    sb.Append(this.RowIndex + Utilities.Instance.SeatMapping[i] + ", ");
                }

                return sb.ToString().Trim().TrimEnd(',');
            }
        }

        public int Precedence { get; set; }
    }
}