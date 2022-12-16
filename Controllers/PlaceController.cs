using IS220.N12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class PlaceController : Controller
    {
        HotelBookingContext context = new HotelBookingContext();

        // GET: Place
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TopDestinations()
        {
            var query3 = (from h in context.HOTELs
                          join r in context.ROOMs on h.HotelID equals r.HotelID
                          join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                          join p in context.PLACEs on h.PlaceID equals p.PlaceID
                          group p by new { p.PlaceID, p.PlaceName } into gr
                          select new
                          {
                              key = gr.Key,
                              amount = gr.Count()
                          }).OrderByDescending(x => x.amount).FirstOrDefault();
            return View();
        }

        // GET: Place/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Place/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Place/Create
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

        // GET: Place/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Place/Edit/5
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

        // GET: Place/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Place/Delete/5
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
