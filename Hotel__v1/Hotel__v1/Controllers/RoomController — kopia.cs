using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel__v1.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        private HotelDBEntities objHotelDbEntities;

        public RoomController()
        {
            objHotelDbEntities = new HotelDBEntities();
        }

        public ActionResult Index()
        {
            RoomViewModel objRoomViewModel = new RoomViewModel();
            objRoomViewModel.ListOfBookingStatus = (from obj in objHotelDbEntities.BookingStatus
                                                    select new SelectListItem()
                                                    {
Text = obj.BookingStatus,
Valur = obj.BookingStatusId.ToString()
                                                    }).toList();

            objRoomViewModel.ListOfRoomType = (from obj in objHotelDbEntities.RoomTypes
                                               select new SelectListItem()
                                               {
                                                   Text = obj.RoomTypeName,
                                                   Valur = obj.RoomTypeId.ToString()
                                               }).toList();
            return View(objRoomViewModel);
        }
    }
}