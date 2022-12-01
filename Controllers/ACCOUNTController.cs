using IS220.N12.Dao;
using IS220.N12.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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

        public ActionResult signUpCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signUpCustomer(string[] values)
        {
            HotelBookingContext context = new HotelBookingContext();
            ACCOUNTDao dao = new ACCOUNTDao();
            dao.signUp(context, values);

            try
            {
                return Json(new
                {
                    msg = "Successfull created account!!!"
                });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult signUpProperty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signUpProperty(string[] values)
        {

            HotelBookingContext context = new HotelBookingContext();
            ACCOUNTDao dao = new ACCOUNTDao();
            dao.signUp(context, values);

            try
            {
                return Json(new
                {
                    msg = "Successfull created account!!!"
                });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult signIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signIn(string username, string password)
        {
            HotelBookingContext context = new HotelBookingContext();

            if (ModelState.IsValid)
            {
                ACCOUNTDao dao = new ACCOUNTDao();
                ACCOUNT account = dao.signIn(context, username, password);

                if (account != null)
                {
                    Session["Account"] = account;

                    switch (account.ROLES)
                    {
                        case 1:
                            return View();
                        case 2:
                            var result2 = from h in context.HOTELs
                                          where h.AccountID == account.AccountID
                                          select h;

                            HOTEL hotel = new HOTEL();
                            foreach (var kq in result2)
                            {
                                hotel.HotelID = kq.HotelID;
                                hotel.HotelName = kq.HotelName;
                                hotel.Address_Hotel = kq.Address_Hotel;
                                hotel.Phone_Hotel = kq.Phone_Hotel;
                                hotel.TypeOfHotel = kq.TypeOfHotel;
                                hotel.Image_Hotel = kq.Image_Hotel;
                                hotel.AccountID = kq.AccountID;
                                hotel.PlaceID = kq.PlaceID;
                            }

                            Session["Hotel"] = hotel;

                            return View();
                        case 3:
                            var result3 = from c in context.CUSTOMERs
                                         where c.AccountID == account.AccountID
                                         select c;

                            CUSTOMER customer = new CUSTOMER();
                            foreach (var kq in result3)
                            {
                                customer.CustomerID = kq.CustomerID;
                                customer.CustomerName = kq.CustomerName;
                                customer.Phone = kq.Phone;
                                customer.Sex = kq.Sex;
                                customer.Status_Account = kq.Status_Account;
                                customer.Image_Customer = kq.Image_Customer;
                                customer.AccountID = kq.AccountID;
                            }

                            Session["Customer"] = customer;

                            return RedirectToAction("../Homepage/Index");
                    }
                }
            } else
            {
                ViewBag.error = "Login Failed!!!";
                return RedirectToAction("Login");
            }
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
