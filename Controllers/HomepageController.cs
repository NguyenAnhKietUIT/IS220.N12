using IS220.N12.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class HomepageController : Controller
    {
        HotelBookingContext context = new HotelBookingContext();
        LinqDataContext ldc = new LinqDataContext();
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

        public JsonResult SearchProperty(string[] values)
        {
            Session["Search"] = values;
            return Json(new { values });
        }

        public JsonResult ShowResultSearch(string[] values)
        {
            string placeName = values[0];
            DateTime checkIn = DateTime.ParseExact(values[1], "yyyy-MM-dd", null);
            DateTime checkOut = DateTime.ParseExact(values[2], "yyyy-MM-dd", null);
            int bedNum = Convert.ToInt32(values[3]);

            List<int> propertyID = new List<int>();
            List<string> propertyName = new List<string>();
            List<string> image = new List<string>();
            List<string> address = new List<string>();
            List<int> price = new List<int>();
            List<string> typeRoom = new List<string>();
            List<double> point = new List<double>();

            var query = ldc.FindProperty(placeName, bedNum, checkIn, checkOut);
            foreach (var item in query)
            {
                propertyID.Add(item.PropertyID);
                propertyName.Add(item.PropertyName);
                image.Add(item.Image_Property);
                address.Add(item.Address_Property);
                price.Add(Convert.ToInt32(item.Price));
                typeRoom.Add(item.TypeOfRoom);
                point.Add((double)item.Point);
            }

            return Json(new {
                propertyID,
                propertyName,
                image,
                address,
                price,
                typeRoom,
                point
            });
        }

        public JsonResult SortByAscending(string[] values)
        {
            string placeName = values[0];
            DateTime checkIn = DateTime.ParseExact(values[1], "yyyy-MM-dd", null);
            DateTime checkOut = DateTime.ParseExact(values[2], "yyyy-MM-dd", null);
            int bedNum = Convert.ToInt32(values[3]);

            List<int> propertyID = new List<int>();
            List<string> propertyName = new List<string>();
            List<string> image = new List<string>();
            List<string> address = new List<string>();
            List<int> price = new List<int>();
            List<string> typeRoom = new List<string>();
            List<double> point = new List<double>();

            var query = ldc.FindPropertyASC(placeName, bedNum, checkIn, checkOut);
            foreach (var item in query)
            {
                propertyID.Add(item.PropertyID);
                propertyName.Add(item.PropertyName);
                image.Add(item.Image_Property);
                address.Add(item.Address_Property);
                price.Add(Convert.ToInt32(item.Price));
                typeRoom.Add(item.TypeOfRoom);
                point.Add((double)item.Point);
            }

            return Json(new
            {
                propertyID,
                propertyName,
                image,
                address,
                price,
                typeRoom,
                point
            });
        }

        public JsonResult SortByDescending(string[] values)
        {
            string placeName = values[0];
            DateTime checkIn = DateTime.ParseExact(values[1], "yyyy-MM-dd", null);
            DateTime checkOut = DateTime.ParseExact(values[2], "yyyy-MM-dd", null);
            int bedNum = Convert.ToInt32(values[3]);

            List<int> propertyID = new List<int>();
            List<string> propertyName = new List<string>();
            List<string> image = new List<string>();
            List<string> address = new List<string>();
            List<int> price = new List<int>();
            List<string> typeRoom = new List<string>();
            List<double> point = new List<double>();

            var query = ldc.FindPropertyDESC(placeName, bedNum, checkIn, checkOut);
            foreach (var item in query)
            {
                propertyID.Add(item.PropertyID);
                propertyName.Add(item.PropertyName);
                image.Add(item.Image_Property);
                address.Add(item.Address_Property);
                price.Add(Convert.ToInt32(item.Price));
                typeRoom.Add(item.TypeOfRoom);
                point.Add((double)item.Point);
            }

            return Json(new
            {
                propertyID,
                propertyName,
                image,
                address,
                price,
                typeRoom,
                point
            });
        }

        public JsonResult SendPlaceName(string[] values)
        {
            Session["SearchPlace"] = values[0];
            return Json(new { values });
        }

        public JsonResult SearchByPlaceName(string[] values)
        {
            string placeName = values[0];

            List<int> propertyID = new List<int>();
            List<string> propertyName = new List<string>();
            List<string> image = new List<string>();
            List<string> address = new List<string>();
            List<int> price = new List<int>();
            List<string> typeRoom = new List<string>();
            List<double> point = new List<double>();

            var query = ldc.ShowPropertyInPlace(placeName);
            foreach (var item in query)
            {
                propertyID.Add(item.PropertyID);
                propertyName.Add(item.PropertyName);
                image.Add(item.Image_Property);
                address.Add(item.Address_Property);
                price.Add(Convert.ToInt32(item.Price));
                typeRoom.Add(item.TypeOfRoom);
                point.Add((double)item.Point);
            }

            return Json(new
            {
                propertyID,
                propertyName,
                image,
                address,
                price,
                typeRoom,
                point
            });
        }

        public JsonResult SendSearchDetail(string[] values)
        {
            Session["SearchProperty"] = values;
            return Json(new
            {
                values
            });
        }

        public JsonResult GetImageProperty(string[] values)
        {
            var propertyID = Convert.ToInt32(values[0]);
            var query = (from r in context.ROOMs
                         where r.PropertyID == propertyID
                         orderby r.RoomID
                         select r.Image_Room).Take(5);

            List<string> images = new List<string>();
            foreach (var kq in query)
            {
                images.Add(kq.ToString());
            }
            return Json(new { images });
        }

        public JsonResult GetInformationProperty(string[] values)
        {
            int propertyID = Convert.ToInt32(values[0]);

            var averagePoint = (from e in context.EVALUATE_PROPERTY
                              where e.PropertyID == propertyID
                              select e.Point).Average();

            var infoProp = (from p in context.PROPERTies
                           where p.PropertyID == propertyID
                           select new
                           {
                               overview = p.Detail_Property,
                               checkInTime = p.CheckInTime,
                               checkOutTime = p.CheckOutTime,
                               location = p.Address_Property
                           }).FirstOrDefault();

            string overview = infoProp.overview;
            string checkInTime = infoProp.checkInTime;
            string checkOutTime = infoProp.checkOutTime;
            string location = infoProp.location;

            var result = ldc.InfoService(propertyID);
            List<string> serviceNames = new List<string>();

            foreach(var kq in result)
            {
                serviceNames.Add(kq.ServiceName);
            }

            var query = (from e in context.EVALUATE_PROPERTY
                         join c in context.CUSTOMERs on e.CustomerID equals c.CustomerID
                         where e.PropertyID == propertyID
                         orderby e.TimeComment descending
                         select new {
                             point = e.Point,
                             name = c.CustomerName,
                             country = c.Country,
                             content = e.Comment,
                             time = e.TimeComment
                         }).FirstOrDefault();

            int point = query.point;
            string name = query.name;
            string country = query.country;
            string content = query.content;
            string time = query.time.ToString("MM/dd/yyyy");

            return Json(new { 
                averagePoint,
                overview,
                checkInTime,
                checkOutTime,
                location,
                serviceNames,
                point,
                name,
                country,
                content,
                time
            });
        }

        public JsonResult GetDataRoom(string[] values)
        {
            int propertyID = Convert.ToInt32(values[0]);
            DateTime checkIn = DateTime.ParseExact(values[1], "yyyy-MM-dd", null);
            DateTime checkOut = DateTime.ParseExact(values[2], "yyyy-MM-dd", null);
            int bedNum = Convert.ToInt32(values[3]);

            var result = ldc.INFOROOM(propertyID, bedNum, checkIn, checkOut);
            List<ROOM> roomList = new List<ROOM>();
            foreach(var kq in result)
            {
                ROOM room = new ROOM();
                room.RoomID = kq.RoomID;
                room.RoomName = kq.RoomName;
                room.TypeOfRoom = kq.TypeOfRoom;
                room.BedNum = kq.BedNum;
                room.Price = kq.Price;
                room.Image_Room = kq.Image_Room;
                room.PropertyID = kq.PropertyID;

                roomList.Add(room);
            };

            return Json(new { roomList });
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
