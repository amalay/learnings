using Amalay.TicketBooking.Models;
using Amalay.TicketBooking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amalay.TicketBooking.Controllers
{
    public class BookingController : Controller
    {
        public BookingController ()
        {
            
        }

        // GET: Booking
        public ActionResult Index()
        {
            BookingModel bookingModel = new BookingModel()
            {
                Seats = 2,
                Planes = PlaneRepository.Instance.GetPlanes()                
            };
            
            return View(bookingModel);
        }

        [HttpPost]
        public ActionResult Search(BookingModel bookingModel)
        {
            try
            {
                List<SeatingModel> availableSeats = null;

                if (bookingModel != null)
                {
                    int planeId = (int)bookingModel.SelectedPlaneId;
                    int noOfSeats = (int)bookingModel.Seats;

                    //bookingModel.Planes = PlaneRepository.Instance.GetPlanes();
                    //var selectedItem = bookingModel.Planes.Find(p => p.Value == bookingModel.SelectedPlaneId.ToString());

                    availableSeats = PlaneRepository.Instance.GetAvailableSeats(planeId, noOfSeats);
                }

                return View("SearchResult", availableSeats);
            }
            catch
            {
                return View();
            }
        }

        //[HttpPost]
        public ActionResult BookTicket(int? planeId, int? rowIndex, int? columnIndex, int? seatLength)
        {
            try
            {
                var result = PlaneRepository.Instance.BookTicket((int)planeId, (int)rowIndex, (int)columnIndex, (int)seatLength);

                List<SeatingModel> availableSeats = PlaneRepository.Instance.GetAvailableSeats((int)planeId, (int)seatLength);

                return View("SearchResult", availableSeats);
            }
            catch
            {
                return View();
            }
        }
    }
}

