﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class ACCOUNTController : Controller
    {
        // GET: ACCOUNT
        public ActionResult Index()
        {
            return View();
        }

        // GET: ACCOUNT/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ACCOUNT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ACCOUNT/Create
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

        // GET: ACCOUNT/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ACCOUNT/Edit/5
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

        // GET: ACCOUNT/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ACCOUNT/Delete/5
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
