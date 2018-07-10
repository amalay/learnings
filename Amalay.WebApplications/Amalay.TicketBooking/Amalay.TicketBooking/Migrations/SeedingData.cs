using Amalay.TicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amalay.TicketBooking.Migrations
{
    public class SeedingData
    {
        #region "Singleton Intance"

        private static readonly SeedingData _Instance = new SeedingData();

        private SeedingData()
        {
            this._Planes = new List<Plane>()
            {
                new Plane() { Id = 1, Name = "Plane 1" },
                new Plane() { Id = 2, Name = "Plane 2" },
                new Plane() { Id = 3, Name = "Plane 3" },
                new Plane() { Id = 3, Name = "Plane 4" },
                new Plane() { Id = 3, Name = "Plane 5" },
                new Plane() { Id = 3, Name = "Plane 6" },
                new Plane() { Id = 3, Name = "Plane 7" },
                new Plane() { Id = 3, Name = "Plane 8" },
                new Plane() { Id = 3, Name = "Plane 9" }
            };
            
            this._Seatings = new List<Seating>()
            {
                new Seating(){ Id = 1, PlaneId = 1, RowIndex = 1, ColumnIndex = 1, IsBooked = false},
                new Seating(){ Id = 2, PlaneId = 1, RowIndex = 1, ColumnIndex = 2, IsBooked = false},
                new Seating(){ Id = 3, PlaneId = 1, RowIndex = 1, ColumnIndex = 3, IsBooked = false},
                new Seating(){ Id = 4, PlaneId = 1, RowIndex = 1, ColumnIndex = 4, IsBooked = false},
                new Seating(){ Id = 5, PlaneId = 1, RowIndex = 1, ColumnIndex = 5, IsBooked = false},
                new Seating(){ Id = 6, PlaneId = 1, RowIndex = 1, ColumnIndex = 6, IsBooked = false},
                new Seating(){ Id = 7, PlaneId = 1, RowIndex = 1, ColumnIndex = 7, IsBooked = false},

                new Seating(){ Id = 8, PlaneId = 1, RowIndex = 2, ColumnIndex = 1, IsBooked = false},
                new Seating(){ Id = 9, PlaneId = 1, RowIndex = 2, ColumnIndex = 2, IsBooked = false},
                new Seating(){ Id = 10, PlaneId = 1, RowIndex = 2, ColumnIndex = 3, IsBooked = false},
                new Seating(){ Id = 11, PlaneId = 1, RowIndex = 2, ColumnIndex = 4, IsBooked = false},
                new Seating(){ Id = 12, PlaneId = 1, RowIndex = 2, ColumnIndex = 5, IsBooked = false},
                new Seating(){ Id = 13, PlaneId = 1, RowIndex = 2, ColumnIndex = 6, IsBooked = false},
                new Seating(){ Id = 14, PlaneId = 1, RowIndex = 2, ColumnIndex = 7, IsBooked = false},

                new Seating(){ Id = 15, PlaneId = 1, RowIndex = 3, ColumnIndex = 1, IsBooked = false},
                new Seating(){ Id = 16, PlaneId = 1, RowIndex = 3, ColumnIndex = 2, IsBooked = false},
                new Seating(){ Id = 17, PlaneId = 1, RowIndex = 3, ColumnIndex = 3, IsBooked = false},
                new Seating(){ Id = 18, PlaneId = 1, RowIndex = 3, ColumnIndex = 4, IsBooked = false},
                new Seating(){ Id = 19, PlaneId = 1, RowIndex = 3, ColumnIndex = 5, IsBooked = false},
                new Seating(){ Id = 20, PlaneId = 1, RowIndex = 3, ColumnIndex = 6, IsBooked = false},
                new Seating(){ Id = 21, PlaneId = 1, RowIndex = 3, ColumnIndex = 7, IsBooked = false},

                new Seating(){ Id = 22, PlaneId = 2, RowIndex = 1, ColumnIndex = 1, IsBooked = false},
                new Seating(){ Id = 23, PlaneId = 2, RowIndex = 1, ColumnIndex = 2, IsBooked = false},
                new Seating(){ Id = 24, PlaneId = 2, RowIndex = 1, ColumnIndex = 3, IsBooked = false},
                new Seating(){ Id = 25, PlaneId = 2, RowIndex = 1, ColumnIndex = 4, IsBooked = false},
                new Seating(){ Id = 26, PlaneId = 2, RowIndex = 1, ColumnIndex = 5, IsBooked = false},
                new Seating(){ Id = 27, PlaneId = 2, RowIndex = 1, ColumnIndex = 6, IsBooked = false},
                new Seating(){ Id = 28, PlaneId = 2, RowIndex = 1, ColumnIndex = 7, IsBooked = false},

                new Seating(){ Id = 29, PlaneId = 2, RowIndex = 2, ColumnIndex = 1, IsBooked = false},
                new Seating(){ Id = 30, PlaneId = 2, RowIndex = 2, ColumnIndex = 2, IsBooked = false},
                new Seating(){ Id = 31, PlaneId = 2, RowIndex = 2, ColumnIndex = 3, IsBooked = false},
                new Seating(){ Id = 32, PlaneId = 2, RowIndex = 2, ColumnIndex = 4, IsBooked = false},
                new Seating(){ Id = 33, PlaneId = 2, RowIndex = 2, ColumnIndex = 5, IsBooked = false},
                new Seating(){ Id = 34, PlaneId = 2, RowIndex = 2, ColumnIndex = 6, IsBooked = false},
                new Seating(){ Id = 35, PlaneId = 2, RowIndex = 2, ColumnIndex = 7, IsBooked = false},
            };
        }

        public static SeedingData Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion
        private List<Plane> _Planes = null;

        private List<Seating> _Seatings = null;

        public IEnumerable<Plane> Planes
        {
            get
            {
                return this._Planes;
            }
        }

        public IEnumerable<Seating> Seatings
        {
            get
            {
                return this._Seatings;
            }
        }
    }
}