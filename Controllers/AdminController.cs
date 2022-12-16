using IS220.N12.Dao;
using IS220.N12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class AdminController : Controller
    {
        HotelBookingContext context = new HotelBookingContext();
        // GET: Admin
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var accountDao = new ACCOUNTDao();
            var model = accountDao.ListAllPaging(page, pageSize);
            return View(model);
        }

        // GET Overall
        public ActionResult Overall()
        {
            var totalCustomer = (from c in context.CUSTOMERs
                        select c.CustomerID).Count();

            var totalHotel = (from h in context.HOTELs
                                 select h.HotelID).Count();

            var totalReservation =  (from r in context.RESERVATIONs
                                     select r.ReservationID).Count();

            return Json(new {
                totalCustomer,
                totalHotel,
                totalReservation
            }, JsonRequestBehavior.AllowGet);
        }

        // GET Customer
        public ActionResult ShowCustomer ()
        {
            List<CUSTOMER> customers = new List<CUSTOMER>();

            var result  = from c in context.CUSTOMERs
                          select c;

            foreach (var kq in result)
            {
                CUSTOMER customer = new CUSTOMER();
                customer.CustomerID = kq.CustomerID;
                customer.CustomerName = kq.CustomerName;
                customer.Country = kq.Country;
                customer.Phone = kq.Phone;
                customer.Sex = kq.Sex;
                customer.Status_Account = kq.Status_Account;
                customer.Image_Customer = kq.Image_Customer;
                customer.AccountID = kq.AccountID;

                customers.Add(customer);

            }
            return Json(new {
                customers
            }, JsonRequestBehavior.AllowGet);
        }

        // GET Customer
        public ActionResult ShowProperty()
        {
            List<HOTEL> hotels = new List<HOTEL>();

            var result = from h in context.HOTELs
                         select h;

            foreach (var kq in result)
            {
                HOTEL hotel = new HOTEL();
                hotel.HotelID = kq.HotelID;
                hotel.HotelName = kq.HotelName;
                hotel.CheckInTime = kq.CheckInTime;
                hotel.CheckOutTime = kq.CheckOutTime;
                hotel.Address_Hotel = kq.Address_Hotel;
                hotel.Detail_Hotel = kq.Detail_Hotel;
                hotel.Phone_Hotel = kq.Phone_Hotel;
                hotel.TypeName = kq.TypeName;
                hotel.Image_Hotel = kq.Image_Hotel;
                hotel.AccountID = kq.AccountID;
                hotel.PlaceID = kq.PlaceID;
                hotel.TypeOfCategory = kq.TypeOfCategory;

                hotels.Add(hotel);

            }
            return Json(new
            {
                hotels
            }, JsonRequestBehavior.AllowGet);
        }

        // GET Message
        public ActionResult AdminMessage()
        {
            return View();
        }

        public ActionResult AdminAnalytics()
        {
            return View();
        }

        public ActionResult DataAnalytics()
        {
            var statusReservation = new int[] {1, 2, 3};

            var query1 = from h in context.HOTELs
                         join r in context.ROOMs on h.HotelID equals r.HotelID
                         join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                         where statusReservation.Contains(re.Status_Reservation)
                         group h by h.TypeOfCategory into gr
                         select new
                         {
                             key = gr.Key,
                             amount = gr.Count()
                         };

            List<string> categoryName = new List<string>();
            List<string> categoryAmount = new List<string>();

            var query2 = from h in context.HOTELs
                         join r in context.ROOMs on h.HotelID equals r.HotelID
                         join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                         where (re.CheckIn.Value.Year == DateTime.Now.Year) && (statusReservation.Contains(re.Status_Reservation))
                         group re by re.CheckIn.Value.Month into gr
                         select new
                         {
                             key = gr.Key,
                             amount = gr.Count()
                         };

            List<string> monthChart = new List<string>();
            List<string> amountBookingChart = new List<string>();

            // Thống kê loại hình property được đặt nhiều nhất
            var query3 = (from h in context.HOTELs
                               join r in context.ROOMs on h.HotelID equals r.HotelID
                               join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                               where statusReservation.Contains(re.Status_Reservation)
                               group h by h.TypeName into gr
                               select new
                               {
                                   key = gr.Key,
                                   amount = gr.Count()
                               }).OrderByDescending(x => x.amount).FirstOrDefault();

            string favouriteTypeName = query3.key;
            string favouriteTypeValue = query3.amount.ToString();

            // Thống kê tháng được đặt nhiều nhất
            var query4 = (from h in context.HOTELs
                          join r in context.ROOMs on h.HotelID equals r.HotelID
                          join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                          where statusReservation.Contains(re.Status_Reservation)
                          group h by re.CheckIn.Value.Month into gr
                          select new
                          {
                              key = gr.Key,
                              amount = gr.Count()
                          }).OrderByDescending(x => x.amount).FirstOrDefault();

            string mostMonth = query4.key.ToString();
            string mostMonthValue = query4.amount.ToString();

            // Propety được book nhiêu nhất
            var query5 = (from h in context.HOTELs
                                   join r in context.ROOMs on h.HotelID equals r.HotelID
                                   join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                                   group h by h.HotelName into gr
                                   select new
                                   {
                                       key = gr.Key,
                                       amount = gr.Count()
                                   }).OrderByDescending(x => x.amount).FirstOrDefault();

            string mostHotel = query5.key;
            string mostHotelValue = query5.amount.ToString();

            // Property được yêu thích nhất
            var query6 = (from h in context.HOTELs
                          join e in context.EVALUATE_HOTEL on h.HotelID equals e.HotelID
                          group new { h, e } by new { h.HotelID, h.HotelName } into gr
                          select new
                          {
                              key = gr.Key.HotelName,
                              average = gr.Average(i => i.e.Point)
                          }).FirstOrDefault();

            string favouriteProperty = query6.key;
            string favouritePropertyValue = query6.average.ToString();


            foreach (var kq1 in query1)
            {
                categoryName.Add(kq1.key);
                categoryAmount.Add(kq1.amount.ToString());
            }

            foreach (var kq2 in query2)
            {
                monthChart.Add(kq2.key.ToString());
                amountBookingChart.Add(kq2.amount.ToString());
            }

            return Json(new
            {
                categoryName,
                categoryAmount,
                monthChart,
                amountBookingChart,
                favouriteTypeName,
                favouriteTypeValue,
                mostMonth,
                mostMonthValue,
                mostHotel,
                mostHotelValue,
                favouriteProperty,
                favouritePropertyValue
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
