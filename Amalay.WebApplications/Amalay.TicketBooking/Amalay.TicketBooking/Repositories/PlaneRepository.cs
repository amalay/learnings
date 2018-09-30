using Amalay.TicketBooking.EntityFramework;
using Amalay.TicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amalay.TicketBooking.Repositories
{
    public class PlaneRepository
    {
        #region "Singleton Intance"

        private static readonly PlaneRepository _Instance = new PlaneRepository();
        
        private PlaneRepository()
        {

        }

        public static PlaneRepository Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        //public IEnumerable<SelectListItem> GetPlanes()
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        List<SelectListItem> planes = context.Planes.AsNoTracking().OrderBy(n => n.Name).Select(n =>
        //        new SelectListItem
        //        {
        //            Text = n.Name,
        //            Value = n.Id.ToString(),
        //        }).ToList();

        //        var plane = new SelectListItem()
        //        {
        //            Text = "--- Select Plane ---",
        //            Value = null
        //        };

        //        planes.Insert(0, plane);

        //        return new SelectList(planes, "Value", "Text");
        //    }
        //}

        public List<SelectListItem> GetPlanes()
        {
            List<SelectListItem> planes = null;

            using (var context = new ApplicationDbContext())
            {
                planes = context.Planes.AsNoTracking().OrderBy(n => n.Name).Select(n =>
                new SelectListItem
                {
                    Text = n.Name,
                    Value = n.Id.ToString(),
                }).ToList();

                var plane = new SelectListItem()
                {
                    Text = "--- Select Plane ---",
                    Value = null
                };

                planes.Insert(0, plane);
            }

            return planes;
        }

        public List<SeatingModel> GetAvailableSeats(int planeId, int noOfSeats)
        {
            var seats = new List<SeatingModel>();

            using (var context = new EntityFramework.AmalayDbEntities())
            {
                var availableSeats = context.USP_GetAvailableSeats(planeId, noOfSeats).ToList();

                if (availableSeats != null && availableSeats.Count() > 0)
                {                    
                    int rowIndex = 0;
                    int columnIndex = 0;

                    try
                    {
                        foreach (var seat in availableSeats)
                        {
                            columnIndex = (int)seat.ColumnIndex;
                            rowIndex = (int)seat.RowIndex;

                            if (columnIndex == 1)
                            {
                                seats.Add(new SeatingModel()
                                {
                                    SeatId = (int)seat.SeatingId,
                                    PlaneId = (int)seat.PlaneId,
                                    RowIndex = rowIndex,
                                    ColumnIndex = columnIndex,
                                    SeatLength = (int)seat.SeatLength,
                                    Precedence = (rowIndex * 10) + 1
                                });
                            }
                            else if (columnIndex == 6)
                            {
                                seats.Add(new SeatingModel()
                                {
                                    SeatId = (int)seat.SeatingId,
                                    PlaneId = (int)seat.PlaneId,
                                    RowIndex = rowIndex,
                                    ColumnIndex = columnIndex,
                                    SeatLength = (int)seat.SeatLength,
                                    Precedence = (rowIndex * 10) + 2
                                });
                            }
                            else if (columnIndex == 3)
                            {
                                seats.Add(new SeatingModel()
                                {
                                    SeatId = (int)seat.SeatingId,
                                    PlaneId = (int)seat.PlaneId,
                                    RowIndex = rowIndex,
                                    ColumnIndex = columnIndex,
                                    SeatLength = (int)seat.SeatLength,
                                    Precedence = (rowIndex * 10) + 3
                                });
                            }
                            else if (columnIndex == 4)
                            {
                                seats.Add(new SeatingModel()
                                {
                                    SeatId = (int)seat.SeatingId,
                                    PlaneId = (int)seat.PlaneId,
                                    RowIndex = rowIndex,
                                    ColumnIndex = columnIndex,
                                    SeatLength = (int)seat.SeatLength,
                                    Precedence = (rowIndex * 10) + 4
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                    }
                }
                
                return seats.OrderBy(s => s.Precedence).ToList();
            }
        }

        public int BookTicket(int planeId, int rowIndex, int columnIndex, int seatLength)
        {
            int result = 0;

            using (var context = new EntityFramework.AmalayDbEntities())
            {
                result = context.USP_BookSeat(planeId, rowIndex, columnIndex, seatLength);
            }

            return result;
        }
    }
}