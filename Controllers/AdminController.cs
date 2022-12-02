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
        // GET: Admin
        public ActionResult Index()
        {
            var accounts = new HotelBookingContext().ACCOUNTs.ToList();
            return View(accounts);
        }

        //GET Overall
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
