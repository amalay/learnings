using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amalay.TicketBooking.Models
{
    public class Utilities
    {
        #region "Singleton Intance"

        private static readonly Utilities _Instance = new Utilities();
        private Dictionary<int, string> seatMapping = null;

        private Utilities()
        {
            seatMapping = new Dictionary<int, string>();
            seatMapping.Add(1, "A");
            seatMapping.Add(2, "B");
            seatMapping.Add(3, "C");
            seatMapping.Add(4, "D");
            seatMapping.Add(5, "E");
            seatMapping.Add(6, "F");
            seatMapping.Add(7, "G");
        }

        public static Utilities Instance
        {
            get
            {
                return _Instance;
            }
        }

        public Dictionary<int, string> SeatMapping
        {
            get
            {
                return this.seatMapping;
            }
        }

        #endregion
    }
}