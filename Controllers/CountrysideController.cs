using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class CountrysideController : Controller
    {
        // GET: Countryside
        public ActionResult Index()
        {
            return View();
        }

        // GET: Countryside/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Countryside/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countryside/Create
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

        // GET: Countryside/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Countryside/Edit/5
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

        // GET: Countryside/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Countryside/Delete/5
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
