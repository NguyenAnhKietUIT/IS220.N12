using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class TropicalController : Controller
    {
        // GET: Tropical
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tropical/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tropical/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tropical/Create
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

        // GET: Tropical/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tropical/Edit/5
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

        // GET: Tropical/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tropical/Delete/5
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
