using IS220.N12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class HomepageController : Controller
    {
        HotelBookingContext context = new HotelBookingContext();
        // GET: Homepage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
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

        public JsonResult CreateMessage(string[] values)
        {
            string usernameSend = "";
            var account = Session["Account"] as ACCOUNT;

            if (account != null)
            {
                usernameSend = account.Username;
            }

            var query = (from a in context.ACCOUNTs
                        where a.ROLES == 1
                        select a.Username).FirstOrDefault();

            CONTACT contact = new CONTACT();
            contact.userNameSend = usernameSend;
            contact.userNameReceive = query.ToString();
            contact.topicType = values[0];
            contact.topicName = values[1];
            contact.fullName = values[2];
            contact.email = values[3];
            contact.message = values[4];

            context.CONTACTs.Add(contact);
            context.SaveChanges();
            return Json(new { msg = contact });
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
