using IS220.N12.Dao;
using IS220.N12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class AdminController : Controller
    {
        HotelBookingContext context = new HotelBookingContext();
        // GET: Admin
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var accountDao = new ACCOUNTDao();
            var model = accountDao.ListAllPaging(page, pageSize);
            return View(model);
        }

        // GET Overall
        public ActionResult Overall()
        {
            var totalCustomer = (from c in context.CUSTOMERs
                        select c.CustomerID).Count();

            var totalHotel = (from p in context.PROPERTies
                                 select p.PropertyID).Count();

            var totalReservation =  (from r in context.RESERVATIONs
                                     select r.ReservationID).Count();

            return Json(new {
                totalCustomer,
                totalHotel,
                totalReservation
            }, JsonRequestBehavior.AllowGet);
        }

        // GET Customer
        public ActionResult ShowCustomer ()
        {
            List<CUSTOMER> customers = new List<CUSTOMER>();

            var result  = from c in context.CUSTOMERs
                          select c;

            foreach (var kq in result)
            {
                CUSTOMER customer = new CUSTOMER();
                customer.CustomerID = kq.CustomerID;
                customer.CustomerName = kq.CustomerName;
                customer.Country = kq.Country;
                customer.Phone = kq.Phone;
                customer.Sex = kq.Sex;
                customer.Status_Account = kq.Status_Account;
                customer.Image_Customer = kq.Image_Customer;
                customer.AccountID = kq.AccountID;

                customers.Add(customer);

            }
            return Json(new {
                customers
            }, JsonRequestBehavior.AllowGet);
        }

        // GET Customer
        public ActionResult ShowProperty()
        {
            List<PROPERTY> properties = new List<PROPERTY>();

            var result = from p in context.PROPERTies
                         select p;

            foreach (var kq in result)
            {
                PROPERTY property = new PROPERTY();
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

                properties.Add(property);

            }
            return Json(new
            {
                properties
            }, JsonRequestBehavior.AllowGet);
        }

        // GET Message
        public ActionResult AdminMessage(int page = 1, int pageSize = 8)
        {
            var contactDao = new CONTACTDao();
            var model = contactDao.ListAllPaging(page, pageSize);

            return View(model);
        }

        public JsonResult DeleteMessage(string[] values)
        {
            int contactID = Convert.ToInt32(values[0]);
            CONTACT contact = context.CONTACTs.Find(contactID);
            context.CONTACTs.Remove(contact);
            context.SaveChanges();
            return Json(new { values }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AdminAnalytics()
        {
            return View();
        }

        public ActionResult DataAnalytics()
        {
            var query1 = from p in context.PROPERTies
                         join r in context.ROOMs on p.PropertyID equals r.PropertyID
                         join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                         group p by p.TypeOfCategory into gr
                         select new
                         {
                             key = gr.Key,
                             amount = gr.Count()
                         };

            List<string> categoryName = new List<string>();
            List<string> categoryAmount = new List<string>();

            var query2 = from p in context.PROPERTies
                         join r in context.ROOMs on p.PropertyID equals r.PropertyID
                         join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                         where (re.CheckIn.Value.Year == DateTime.Now.Year)
                         group re by re.CheckIn.Value.Month into gr
                         select new
                         {
                             key = gr.Key,
                             amount = gr.Count()
                         };

            List<string> monthChart = new List<string>();
            List<string> amountBookingChart = new List<string>();

            // Thống kê loại hình property được đặt nhiều nhất
            var query3 = (from p in context.PROPERTies
                               join r in context.ROOMs on p.PropertyID equals r.PropertyID
                               join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                               group p by p.TypeName into gr
                               select new
                               {
                                   key = gr.Key,
                                   amount = gr.Count()
                               }).OrderByDescending(x => x.amount).FirstOrDefault();

            string favouriteTypeName = query3.key;
            string favouriteTypeValue = query3.amount.ToString();

            // Thống kê tháng được đặt nhiều nhất
            var query4 = (from p in context.PROPERTies
                          join r in context.ROOMs on p.PropertyID equals r.PropertyID
                          join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                          group p by re.CheckIn.Value.Month into gr
                          select new
                          {
                              key = gr.Key,
                              amount = gr.Count()
                          }).OrderByDescending(x => x.amount).FirstOrDefault();

            string mostMonth = query4.key.ToString();
            string mostMonthValue = query4.amount.ToString();

            // Propety được book nhiêu nhất
            var query5 = (from p in context.PROPERTies
                                   join r in context.ROOMs on p.PropertyID equals r.PropertyID
                                   join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                                   group p by p.PropertyName into gr
                                   select new
                                   {
                                       key = gr.Key,
                                       amount = gr.Count()
                                   }).OrderByDescending(x => x.amount).FirstOrDefault();

            string mostHotel = query5.key;
            string mostHotelValue = query5.amount.ToString();

            // Property được yêu thích nhất
            var query6 = (from p in context.PROPERTies
                          join e in context.EVALUATE_PROPERTY on p.PropertyID equals e.PropertyID
                          group new { p, e } by new { p.PropertyID, p.PropertyName} into gr
                          select new
                          {
                              key = gr.Key.PropertyName,
                              average = gr.Sum(i => i.e.Point) / gr.Count()
                          }).OrderByDescending(x => x.average).FirstOrDefault();

            string favouriteProperty = query6.key;
            string favouritePropertyValue = query6.average.ToString();


            foreach (var kq1 in query1)
            {
                categoryName.Add(kq1.key);
                categoryAmount.Add(kq1.amount.ToString());
            }

            foreach (var kq2 in query2)
            {
                monthChart.Add(kq2.key.ToString());
                amountBookingChart.Add(kq2.amount.ToString());
            }

            return Json(new
            {
                categoryName,
                categoryAmount,
                monthChart,
                amountBookingChart,
                favouriteTypeName,
                favouriteTypeValue,
                mostMonth,
                mostMonthValue,
                mostHotel,
                mostHotelValue,
                favouriteProperty,
                favouritePropertyValue
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
