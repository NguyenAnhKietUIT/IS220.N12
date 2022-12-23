using IS220.N12.Dao;
using IS220.N12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class PropertyController : Controller
    {
        HotelBookingContext context = new HotelBookingContext();
        LinqDataContext ldc = new LinqDataContext();
        // GET: Property
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult HomeProperty()
        {
            var property = Session["Property"] as PROPERTY;

            var total = (from re in context.RESERVATIONs
                        join r in context.ROOMs on re.RoomID equals r.RoomID
                        where r.PropertyID == property.PropertyID
                        select re.ReservationID).Count();

            var arrival = (from re in context.RESERVATIONs
                           join r in context.ROOMs on re.RoomID equals r.RoomID
                           where r.PropertyID == property.PropertyID && re.Status_Reservation == 3
                           select re.ReservationID).Count();

            var departure = (from re in context.RESERVATIONs
                             join r in context.ROOMs on re.RoomID equals r.RoomID
                             where r.PropertyID == property.PropertyID && re.Status_Reservation == 2
                             select re.ReservationID).Count();

            var review = (from e in context.EVALUATE_PROPERTY
                          where e.PropertyID == property.PropertyID
                          select e.evaPropertyID).Count();
            return Json(new {
                total, 
                arrival, 
                departure, 
                review
            });
        }

        public JsonResult DayFull(string[] values)
        {
            var property = Session["Property"] as PROPERTY;

            DateTime from = DateTime.ParseExact(values[0], "yyyy-MM-dd", null);
            DateTime until = DateTime.ParseExact(values[1], "yyyy-MM-dd", null);

            var query = ldc.STATISTICDAY_FULL(from, until, property.PropertyID);

            List<string> key = new List<string>();
            List<string> value = new List<string>();

            foreach (var item in query)
            {
                key.Add(item.Day.ToString());
                value.Add(item.total.ToString());
            }

            return Json(new { key, value });
        }

        public JsonResult DayStart(string[] values)
        {
            var property = Session["Property"] as PROPERTY;
            DateTime date = DateTime.ParseExact(values[0], "yyyy-MM-dd", null);

            var query = ldc.STATISTICDAY_START(date, property.PropertyID);

            List<string> key = new List<string>();
            List<string> value = new List<string>();

            foreach(var item in query)
            {
                key.Add(item.Day.ToString());
                value.Add(item.total.ToString());
            }

            return Json(new { key, value });
        }

        public JsonResult DayEnd(string[] values)
        {
            var property = Session["Property"] as PROPERTY;
            DateTime date = DateTime.ParseExact(values[0], "yyyy-MM-dd", null);

            var query = ldc.STATISTICDAY_END(date, property.PropertyID);

            List<string> key = new List<string>();
            List<string> value = new List<string>();

            foreach (var item in query)
            {
                key.Add(item.Day.ToString());
                value.Add(item.total.ToString());
            }

            return Json(new { key, value });
        }

        public JsonResult MonthFull(string[] values)
        {
            var property = Session["Property"] as PROPERTY;

            DateTime from = DateTime.ParseExact(values[0], "yyyy-MM-dd", null);
            DateTime until = DateTime.ParseExact(values[1], "yyyy-MM-dd", null);

            var query = ldc.STATISTICMONTH_FULL(from, until, property.PropertyID);

            List<string> key = new List<string>();
            List<string> value = new List<string>();

            foreach (var item in query)
            {
                key.Add(item.Month.ToString());
                value.Add(item.total.ToString());
            }

            return Json(new { key, value });
        }

        public JsonResult MonthStart(string[] values)
        {
            var property = Session["Property"] as PROPERTY;
            DateTime date = DateTime.ParseExact(values[0], "yyyy-MM-dd", null);

            var query = ldc.STATISTICMONTH_START(date, property.PropertyID);

            List<string> key = new List<string>();
            List<string> value = new List<string>();

            foreach (var item in query)
            {
                key.Add(item.Month.ToString());
                value.Add(item.total.ToString());
            }

            return Json(new { key, value });
        }

        public JsonResult MonthEnd(string[] values)
        {
            var property = Session["Property"] as PROPERTY;
            DateTime date = DateTime.ParseExact(values[0], "yyyy-MM-dd", null);

            var query = ldc.STATISTICMONTH_END(date, property.PropertyID);

            List<string> key = new List<string>();
            List<string> value = new List<string>();

            foreach (var item in query)
            {
                key.Add(item.Month.ToString());
                value.Add(item.total.ToString());
            }

            return Json(new { key, value });
        }

        public JsonResult YearFull(string[] values)
        {
            var property = Session["Property"] as PROPERTY;

            DateTime from = DateTime.ParseExact(values[0], "yyyy-MM-dd", null);
            DateTime until = DateTime.ParseExact(values[1], "yyyy-MM-dd", null);

            var query = ldc.STATISTICYEAR_FULL(from, until, property.PropertyID);

            List<string> key = new List<string>();
            List<string> value = new List<string>();

            foreach (var item in query)
            {
                key.Add(item.year.ToString());
                value.Add(item.total.ToString());
            }

            return Json(new { key, value });
        }

        public JsonResult YearStart(string[] values)
        {
            var property = Session["Property"] as PROPERTY;
            DateTime date = DateTime.ParseExact(values[0], "yyyy-MM-dd", null);

            var query = ldc.STATISTICYEAR_START(date, property.PropertyID);

            List<string> key = new List<string>();
            List<string> value = new List<string>();

            foreach (var item in query)
            {
                key.Add(item.Year.ToString());
                value.Add(item.total.ToString());
            }

            return Json(new { key, value });
        }

        public JsonResult YearEnd(string[] values)
        {
            var property = Session["Property"] as PROPERTY;
            DateTime date = DateTime.ParseExact(values[0], "yyyy-MM-dd", null);

            var query = ldc.STATISTICYEAR_END(date, property.PropertyID);

            List<string> key = new List<string>();
            List<string> value = new List<string>();

            foreach (var item in query)
            {
                key.Add(item.Year.ToString());
                value.Add(item.total.ToString());
            }

            return Json(new { key, value });
        }

        public ActionResult Manage_Room(int page = 1, int pageSize = 5)
        {
            var property = Session["Property"] as PROPERTY;
            PROPERTYDao propertyDao = new PROPERTYDao();
            var model = propertyDao.ListAllPaging(property.PropertyID, page, pageSize);
            return View(model);
        }

        public JsonResult UpdateRoom(string[] values)
        {
            var property = Session["Property"] as PROPERTY;
            ROOM r = new ROOM();
            r.RoomID = Convert.ToInt32(values[0]);
            r.RoomName = values[1];
            r.TypeOfRoom = values[2];
            r.BedNum = Convert.ToInt32(values[3]);
            r.Price = Convert.ToDecimal(values[4]);
            r.Image_Room = values[5];
            r.PropertyID = property.PropertyID;

            ROOMDao dao = new ROOMDao();
            bool isSuccess = dao.UpdateRoom(r);
            return Json(new { isSuccess });
        }

        public JsonResult DeleteRoom(string[] values)
        {
            int roomID = Convert.ToInt32(values[0]);
            
            bool isSuccess = false;
            try
            {
                ROOM room = context.ROOMs.Find(roomID);
                context.ROOMs.Remove(room);
                context.SaveChanges();
                isSuccess = true;
            } catch
            {
                isSuccess = false;
            }
            return Json(new { isSuccess });
        }

        public JsonResult GetInbox()
        {
            var account = Session["Account"] as ACCOUNT;

            var query = from c in context.CONTACTs
                        where c.userNameReceive == account.Username
                        select new
                        {
                            usernameSend = c.userNameSend,
                            content = c.message
                        };

            List<string> usernameSends = new List<string>();
            List<string> contents = new List<string>();

            foreach (var item in query)
            {
                usernameSends.Add(item.usernameSend);
                contents.Add(item.content);
            }
            return Json(new
            {
                usernameSends,
                contents
            });
        }

        public ActionResult Information()
        {
            return View();
        }

        public JsonResult UpdateInformation(string[] values)
        {
            var account = Session["Account"] as ACCOUNT;

            PROPERTY property = new PROPERTY();
            property.PropertyName = values[0];
            property.CheckInTime = values[1];
            property.CheckOutTime = values[2];
            property.Address_Property = values[3];
            property.Detail_Property = values[4];
            property.Phone_Property = values[5];
            property.TypeName = values[6];
            property.Image_Property = values[7];
            property.AccountID = account.AccountID;
            property.TypeOfCategory = values[8];

            PROPERTYDao dao = new PROPERTYDao();
            bool isSuccess = dao.UpdateInormation(property);

            return Json(new { isSuccess });
        }

        public ActionResult RatesAndAvailability()
        {
            return View();
        }

        public JsonResult GetRates()
        {
            var property = Session["Property"] as PROPERTY;
            var query = ldc.LIST_RATES(property.PropertyID);

            List<int> quantities = new List<int>();
            List<string> type = new List<string>();
            List<double> avgPrice = new List<double>();
            List<int> status = new List<int>();

            foreach(var item in query)
            {
                quantities.Add(Convert.ToInt32(item.Quantity));
                type.Add(item.TypeOfRoom);
                avgPrice.Add(Convert.ToDouble(item.Price));
                status.Add(item.Status_Reservation);
            }

            return Json(new {
                quantities, 
                type, 
                avgPrice, 
                status
            });
        }

        public JsonResult GetRatesFilter(string[] values)
        {
            var property = Session["Property"] as PROPERTY;
            string typeRoom = values[0];
            int statusInput = Convert.ToInt32(values[1]);
            var query = ldc.LIST_RATES_FILTER(property.PropertyID, typeRoom, statusInput);

            List<int> quantities = new List<int>();
            List<string> type = new List<string>();
            List<double> avgPrice = new List<double>();
            List<int> status = new List<int>();

            foreach (var item in query)
            {
                quantities.Add(Convert.ToInt32(item.Quantity));
                type.Add(item.TypeOfRoom);
                avgPrice.Add(Convert.ToDouble(item.Price));
                status.Add(item.Status_Reservation);
            }

            return Json(new
            {
                quantities,
                type,
                avgPrice,
                status
            });
        }

        public ActionResult Manage_Reservation()
        {
            return View();
        }

        public JsonResult GetReservation()
        {
            var property = Session["Property"] as PROPERTY;
            var query = from re in context.RESERVATIONs
                        join r in context.ROOMs on re.RoomID equals r.RoomID
                        where r.PropertyID == property.PropertyID
                        select new
                        {
                            reservationID = re.ReservationID,
                            bedNum = r.BedNum,
                            checkIn = re.CheckIn,
                            checkOut = re.CheckOut,
                            typeRoom = r.TypeOfRoom,
                            status = re.Status_Reservation,
                            total = re.Total
                        };
            List<int> reservationIDs = new List<int>();
            List<int> bedNums = new List<int>();
            List<string> checkIns = new List<string>();
            List<string> checkOuts = new List<string>();
            List<string> typeRooms = new List<string>();
            List<int> status = new List<int>();
            List<int> totals = new List<int>();

            foreach(var item in query)
            {
                reservationIDs.Add(item.reservationID);
                bedNums.Add(item.bedNum);
                checkIns.Add(((DateTime)item.checkIn).ToString("MM/dd/yyyy"));
                checkOuts.Add(((DateTime)item.checkOut).ToString("MM/dd/yyyy"));
                typeRooms.Add(item.typeRoom.ToString());
                status.Add(item.status);
                totals.Add(Convert.ToInt32(item.total));
            }
            return Json(new {
                reservationIDs,
                bedNums,
                checkIns,
                checkOuts,
                typeRooms,
                status,
                totals
            });
        }

        public JsonResult UpdateStatus(string[] values)
        {
            RESERVATIONDao dao = new RESERVATIONDao();
            bool isSuccess = dao.UpdateStatus(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
            return Json(new { isSuccess });
        }

        public JsonResult SearchBasic(string[] values)
        {
            var property = Session["Property"] as PROPERTY;
            int choice = Convert.ToInt32(values[0]);
            DateTime from = DateTime.ParseExact(values[1], "yyyy-MM-dd", null);
            DateTime until = DateTime.ParseExact(values[2], "yyyy-MM-dd", null);
            var query = ldc.PROPERTY_RESERVATION_BASIC(property.PropertyID, choice, from, until);

            List<int> reservationIDs = new List<int>();
            List<int> bedNums = new List<int>();
            List<string> checkIns = new List<string>();
            List<string> checkOuts = new List<string>();
            List<string> typeRooms = new List<string>();
            List<int> status = new List<int>();
            List<int> totals = new List<int>();

            foreach (var item in query)
            {
                reservationIDs.Add(item.ReservationID);
                bedNums.Add(item.BedNum);
                checkIns.Add(((DateTime)item.CheckIn).ToString("MM/dd/yyyy"));
                checkOuts.Add(((DateTime)item.CheckOut).ToString("MM/dd/yyyy"));
                typeRooms.Add(item.TypeOfRoom);
                status.Add(item.Status_Reservation);
                totals.Add(Convert.ToInt32(item.Total));
            }
            return Json(new
            {
                reservationIDs,
                bedNums,
                checkIns,
                checkOuts,
                typeRooms,
                status,
                totals
            });
        }

        public JsonResult SearchByType(string[] values)
        {
            var property = Session["Property"] as PROPERTY;
            int choice = Convert.ToInt32(values[0]);
            DateTime from = DateTime.ParseExact(values[1], "yyyy-MM-dd", null);
            DateTime until = DateTime.ParseExact(values[2], "yyyy-MM-dd", null);
            string type = values[3];
            var query = ldc.PROPERTY_RESERVATION_TYPEROOM(property.PropertyID, choice, from, until, type);

            List<int> reservationIDs = new List<int>();
            List<int> bedNums = new List<int>();
            List<string> checkIns = new List<string>();
            List<string> checkOuts = new List<string>();
            List<string> typeRooms = new List<string>();
            List<int> status = new List<int>();
            List<int> totals = new List<int>();

            foreach (var item in query)
            {
                reservationIDs.Add(item.ReservationID);
                bedNums.Add(item.BedNum);
                checkIns.Add(((DateTime)item.CheckIn).ToString("MM/dd/yyyy"));
                checkOuts.Add(((DateTime)item.CheckOut).ToString("MM/dd/yyyy"));
                typeRooms.Add(item.TypeOfRoom);
                status.Add(item.Status_Reservation);
                totals.Add(Convert.ToInt32(item.Total));
            }
            return Json(new
            {
                reservationIDs,
                bedNums,
                checkIns,
                checkOuts,
                typeRooms,
                status,
                totals
            });
        }

        public ActionResult Manage_Review()
        {
            return View();
        }

        public JsonResult GetReview()
        {
            var property = Session["Property"] as PROPERTY;
            var query = from e in context.EVALUATE_PROPERTY
                        join c in context.CUSTOMERs on e.CustomerID equals c.CustomerID
                        join a in context.ACCOUNTs on c.AccountID equals a.AccountID
                        where e.PropertyID == property.PropertyID
                        select new
                        {
                            image = c.Image_Customer,
                            name = c.CustomerName,
                            gmail = a.GMAIL,
                            point = e.Point,
                            comment = e.Comment
                        };

            List<string> images = new List<string>();
            List<string> names = new List<string>();
            List<string> gmails = new List<string>();
            List<int> points = new List<int>();
            List<string> comments = new List<string>();

            foreach(var item in query)
            {
                images.Add(item.image);
                names.Add(item.name);
                gmails.Add(item.gmail);
                points.Add(item.point);
                comments.Add(item.comment);
            }
            return Json(new { 
                images,
                names,
                gmails,
                points,
                comments,
            });
        }

        // GET: Property/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Property/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Property/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Property/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Property/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Property/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
