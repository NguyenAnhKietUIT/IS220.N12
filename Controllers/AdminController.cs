using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var accounts = new HotelBookingContext().ACCOUNTs.ToList();
            return View(accounts);
        }

        // GET Overall
        public ActionResult Overall()
        {
            HotelBookingContext context= new HotelBookingContext();

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
            HotelBookingContext context= new HotelBookingContext();
            List<CUSTOMER> customers = new List<CUSTOMER>();

            var result  = from c in context.CUSTOMERs
                          select c;

            foreach (var kq in result)
            {
                CUSTOMER customer = new CUSTOMER();
                customer.CustomerID = kq.CustomerID;
                customer.CustomerName = kq.CustomerName;
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
            HotelBookingContext context = new HotelBookingContext();
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
                hotel.TypeID = kq.TypeID;
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
