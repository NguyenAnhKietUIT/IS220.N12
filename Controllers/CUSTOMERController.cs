using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class CUSTOMERController : Controller
    {
        // GET: CUSTOMER
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YourAccount()
        {
            return View();
        }
        public ActionResult ViewAllBooking()
        {
            return View();
        }

        public ActionResult Detail_Booking()
        {
            return View();
        }

        public ActionResult Review_Property()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Reservation()
        {
            return View();
        }

        // GET: CUSTOMER/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CUSTOMER/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CUSTOMER/Create
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

        // GET: CUSTOMER/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CUSTOMER/Edit/5
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

        // GET: CUSTOMER/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CUSTOMER/Delete/5
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
