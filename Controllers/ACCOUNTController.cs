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
        HotelBookingContext context = new HotelBookingContext();

        // GET: ACCOUNT
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CheckUsernameExists(string[] values)
        {
            var result = values[0];
            return Json(context.ACCOUNTs.Any(x => x.Username == result), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckGmailExists(string[] values)
        {
            var result = values[0];
            return Json(context.ACCOUNTs.Any(x => x.GMAIL == result), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SignUpCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUpCustomer(string[] values)
        {
            ACCOUNTDao dao = new ACCOUNTDao();
            bool isSuccess = dao.signUp(values);

            try
            {
                return Json(new
                {
                    isSuccess
                });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SignUpProperty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUpProperty(string[] values)
        {

            ACCOUNTDao dao = new ACCOUNTDao();
            bool isSuccess = dao.signUp(values);

            try
            {
                return Json(new
                {
                    isSuccess
                });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string username, string password)
        {
            if (ModelState.IsValid)
            {
                ACCOUNTDao dao = new ACCOUNTDao();
                ACCOUNT account = dao.signIn(username, password);

                if (account != null)
                {
                    Session["Account"] = account;

                    switch (account.ROLES)
                    {
                        case 1:
                            return RedirectToAction("../Admin/Index");
                        case 2:
                            var result2 = from p in context.PROPERTies
                                          where p.AccountID == account.AccountID
                                          select p;

                            PROPERTY property = new PROPERTY();
                            foreach (var kq in result2)
                            {
                                property.PropertyID = kq.PropertyID;
                                property.PropertyName = kq.PropertyName;
                                property.CheckInTime = kq.CheckInTime;
                                property.CheckOutTime = kq.CheckOutTime;
                                property.Address_Property = kq.Address_Property;
                                property.Detail_Property = kq.Detail_Property;
                                property.Phone_Property = kq.Phone_Property;
                                property.TypeName = kq.TypeName;
                                property.Image_Property = kq.Image_Property;
                                property.AccountID = kq.AccountID;
                                property.PlaceID = kq.PlaceID;
                                property.TypeOfCategory = kq.TypeOfCategory;
                            }

                            Session["Property"] = property;

                            return RedirectToAction("../Property/Index");
                        case 3:
                            var result3 = from c in context.CUSTOMERs
                                         where c.AccountID == account.AccountID
                                         select c;

                            CUSTOMER customer = new CUSTOMER();
                            foreach (var kq in result3)
                            {
                                customer.CustomerID = kq.CustomerID;
                                customer.CustomerName = kq.CustomerName;
                                customer.Country = kq.Country;
                                customer.Phone = kq.Phone;
                                customer.Sex = kq.Sex;
                                customer.Status_Account = kq.Status_Account;
                                customer.Image_Customer = kq.Image_Customer;
                                customer.AccountID = kq.AccountID;
                            }

                            Session["Customer"] = customer;

                            return RedirectToAction("../CUSTOMER/YourAccount");
                    }
                }
            } else
            {
                return RedirectToAction("SignIn");
            }
            return View();
        }

        public JsonResult SignOut()
        {
            Session.Clear();

            return Json(new
            {
                msg = "Successfull sign out!!!"
            });
        }

        public ActionResult Edit_Password()
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
