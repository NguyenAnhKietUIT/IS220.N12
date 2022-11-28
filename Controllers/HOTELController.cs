using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class HOTELController : Controller
    {
        // GET: HOTEL
        public ActionResult Index()
        {
            return View();
        }

        // GET: HOTEL/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HOTEL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HOTEL/Create
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

        // GET: HOTEL/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HOTEL/Edit/5
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

        // GET: HOTEL/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HOTEL/Delete/5
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
