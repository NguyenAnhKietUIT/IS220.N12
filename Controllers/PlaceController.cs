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
            var query = (from p in context.PROPERTies
                          join r in context.ROOMs on p.PropertyID equals r.PropertyID
                          join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                          join pl in context.PLACEs on p.PlaceID equals pl.PlaceID
                          group pl by new { pl.PlaceID, pl.PlaceName, pl.ImageOfPlace } into gr
                          select new
                          {
                              key = gr.Key,
                              amount = gr.Count()
                          }).OrderByDescending(x => x.amount).Take(4);

            List<string> placeName = new List<string>();
            List<string> placeImage = new List<string>();

            foreach (var kq in query)
            {
                placeName.Add(kq.key.PlaceName);
                placeImage.Add(kq.key.ImageOfPlace);
            }

            return Json(new
            {
                placeName, placeImage
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TopTitle(string[] values)
        {
            string categoryName = values[0];

            var destinations = (from p in context.PROPERTies
                              join pl in context.PLACEs on p.PlaceID equals pl.PlaceID
                              where p.TypeOfCategory == categoryName
                              group pl by new { pl.PlaceID, pl.PlaceName, pl.ImageOfPlace } into gr
                              select new
                              {
                                  key = gr.Key,
                                  amount = gr.Count()
                              }).OrderByDescending(x => x.amount).Take(4);

            List<int> idDestinations = new List<int>();
            List<string> nameDestinations = new List<string>();
            List<string> imageDestinations = new List<string>();

            foreach (var beach in destinations)
            {
                idDestinations.Add(beach.key.PlaceID);
                nameDestinations.Add(beach.key.PlaceName);
                imageDestinations.Add(beach.key.ImageOfPlace);
            }
            return Json(new {
                idDestinations,
                imageDestinations,
                nameDestinations,
            });
        }

        public JsonResult Analytic(string[] values)
        {
            int placeID = Convert.ToInt32(values[0]);

            var query = (from p in context.PROPERTies
                         where p.PlaceID == placeID
                         group p by p.TypeName into gr
                         select new
                         {
                             key = gr.Key,
                             amount = gr.Count()
                         }).OrderBy(x => x.key);

            List<string> names = new List<string>();
            List<int> amounts = new List<int>();
            foreach (var item in query)
            {
                names.Add(item.key);
                amounts.Add(item.amount);
            }
            return Json(new { names, amounts });
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
