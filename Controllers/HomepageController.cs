using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Article_1()
        {
            return View();
        }

        public ActionResult Article_2()
        {
            return View();
        }

        public ActionResult Article_3()
        {
            return View();
        }

        public ActionResult Article_4()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Search_Detail()
        {
            return View();
        }

        // GET: Homepage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Homepage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Homepage/Create
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

        // GET: Homepage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Homepage/Edit/5
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

        // GET: Homepage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Homepage/Delete/5
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
