using IS220.N12.Dao;
using IS220.N12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Controllers
{
    public class CUSTOMERController : Controller
    {
        HotelBookingContext context = new HotelBookingContext();
        LinqDataContext ldc = new LinqDataContext();
        // GET: CUSTOMER
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YourAccount()
        {
            return View();
        }
        public JsonResult UpdateInformation(string[] values)
        {
            CUSTOMER customer = new CUSTOMER();
            customer.CustomerName = values[0];
            customer.Country = values[1];
            customer.Sex = Convert.ToInt32(values[2]);
            customer.Phone = values[3];
            customer.Image_Customer = values[4];
            customer.Status_Account = 1;
            customer.AccountID = Convert.ToInt32(values[5]);

            CUSTOMERDao dao = new CUSTOMERDao();
            bool update = dao.UpdateInormation(customer);

            return Json(new
            {
                update
            });
        }
        public ActionResult ViewAllBooking()
        {
            return View();
        }
        public JsonResult GetUpComingBooking()
        {
            var customer = Session["Customer"] as CUSTOMER;

            var result = ldc.UPCOMMING(customer.CustomerID);

            List<string> imageRoom = new List<string>();
            List<string> propertyName = new List<string>();
            List<string> roomName = new List<string>();
            List<string> checkInTime = new List<string>();
            List<string> checkInDate = new List<string>();
            List<string> total = new List<string>();
            List<string> typeRoom = new List<string>();

            foreach (var item in result)
            {
                imageRoom.Add(item.Image_Room);
                propertyName.Add(item.PropertyName);
                roomName.Add(item.RoomName);
                checkInTime.Add(item.CheckInTime);
                checkInDate.Add(((DateTime)item.CheckIn).ToString("MM/dd/yyyy"));
                total.Add(item.Total.ToString());
                typeRoom.Add(item.TypeOfRoom);
            }
            return Json(new
            {
                imageRoom,
                propertyName,
                roomName,
                checkInTime,
                checkInDate,
                total,
                typeRoom,
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPastBooking()
        {
            var customer = Session["Customer"] as CUSTOMER;

            int[] statusPast = new int[3] {2, 4, 5};

            var query = from r in context.ROOMs
                        join p in context.PROPERTies on r.PropertyID equals p.PropertyID
                        join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                        where re.CustomerID == customer.CustomerID
                        && DateTime.Compare((DateTime)re.CheckOut, DateTime.Now) <= 0
                        && statusPast.Contains(re.Status_Reservation)
                        select new
                        {
                            imageRoom = r.Image_Room,
                            propertyName = p.PropertyName,
                            roomName = r.RoomName,
                            status = re.Status_Reservation,
                            total = (long)re.Total,
                            typeRoom = r.TypeOfRoom
                        };

            List<string> imageRoom = new List<string>();
            List<string> propertyName = new List<string>();
            List<string> roomName = new List<string>();
            List<string> status = new List<string>();
            List<string> total = new List<string>();
            List<string> typeRoom = new List<string>();

            foreach (var kq in query)
            {
                imageRoom.Add(kq.imageRoom);
                propertyName.Add(kq.propertyName);
                roomName.Add(kq.roomName);
                if (kq.status == 1)
                {
                    status.Add("Booked");
                } else if (kq.status == 2)
                {
                    status.Add("Checked out");
                }
                else if (kq.status == 3)
                {
                    status.Add("Live in");
                }
                else if (kq.status == 4)
                {
                    status.Add("Cancelled");
                } else
                {
                    status.Add("No show");
                };
                total.Add(kq.total.ToString());
                typeRoom.Add(kq.typeRoom);
            }
            return Json(new {
                imageRoom,
                propertyName,
                roomName,
                status,
                total,
                typeRoom,
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SeeDetailBooking(string[] values)
        {
            Session["DetailBooking"] = values;

            return Json(new
            {
                msg = values
            });
        }
        public JsonResult GetDetailBooking(string[] values)
        {
            var account = Session["Account"] as ACCOUNT;
            string propertyName = values[0];
            string roomName = values[1];

            var query = (from re in context.RESERVATIONs
                        join r in context.ROOMs on re.RoomID equals r.RoomID
                        join p in context.PROPERTies on r.PropertyID equals p.PropertyID
                        join c in context.CUSTOMERs on re.CustomerID equals c.CustomerID
                        join a in context.ACCOUNTs on c.AccountID equals a.AccountID
                        where String.Compare(p.PropertyName, propertyName, false) == 0
                        && String.Compare(r.RoomName, roomName, false) == 0
                        && a.AccountID == account.AccountID
                        select new
                        {
                            imageRoom = r.Image_Room,
                            reservationID = re.ReservationID,
                            phone = p.Phone_Property,
                            address = p.Address_Property,
                            checkInDate = re.CheckIn,
                            checkOutDate = re.CheckOut,
                            checkInTime = p.CheckInTime,
                            checkOutTime = p.CheckOutTime,
                            status = re.Status_Reservation
                        }).FirstOrDefault();

            var avg = (from p in context.PROPERTies
                       join e in context.EVALUATE_PROPERTY on p.PropertyID equals e.PropertyID
                       join r in context.ROOMs on p.PropertyID equals r.PropertyID
                       join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                       where String.Compare(p.PropertyName, propertyName, false) == 0
                       select e).Average(x => x.Point);

            string imageRoom = query.imageRoom;
            string reservationID = query.reservationID.ToString();
            string phone = query.phone.ToString();
            string address = query.address.ToString();
            string checkInDate = ((DateTime)query.checkInDate).ToString("MM/dd/yyyy");
            string checkOutDate = ((DateTime)query.checkOutDate).ToString("MM/dd/yyyy");
            string checkInTime = query.checkInTime;
            string checkOutTime = query.checkOutTime;
            string average = avg.ToString();
            string status;

            if (query.status == 1)
            {
                status = "Booked";
            }
            else if (query.status == 2)
            {
                status = "Checked out";
            }
            else if (query.status == 3)
            {
                status = "Live in";
            }
            else if (query.status == 4)
            {
                status = "Cancelled";
            }
            else
            {
                status = "No show";
            };

            return Json(new {
                imageRoom,
                propertyName,
                reservationID,
                phone,
                address,
                average,
                checkInDate,
                checkOutDate,
                checkInTime,
                checkOutTime,
                status
            });
        }
        public JsonResult UpdateStatusReservation(string[] values)
        {
            int reservationID = Convert.ToInt32(values[0]);
            Session["ReservationID"] = reservationID;

            CUSTOMERDao dao = new CUSTOMERDao();
            bool status = dao.UpdateStatusReservation(reservationID);

            return Json(new { 
                status
            });
        }
        public JsonResult RedirectReviewPage(string[] values)
        {
            Session["ReservationID"] = values[0];
            return Json(new { msg = values[0] });
        }
        public JsonResult GetInfoProReview(string[] values)
        {
            int reservationID = Convert.ToInt32(values[0]);
            var query = (from re in context.RESERVATIONs
                        join r in context.ROOMs on re.RoomID equals r.RoomID
                        join p in context.PROPERTies on r.PropertyID equals p.PropertyID
                        where re.ReservationID == reservationID
                        select new
                        {
                            image = p.Image_Property,
                            name = p.PropertyName,
                            address = p.Address_Property,
                            checkIn = re.CheckIn,
                            checkOut = re.CheckOut,
                            status = re.Status_Reservation
                        }).FirstOrDefault();

            string image = query.image;
            string name = query.name;
            string address = query.address;
            string checkIn = ((DateTime)query.checkIn).ToString("MM/dd/yyyy");
            string checkOut = ((DateTime)query.checkOut).ToString("MM/dd/yyyy");
            string status;

            if (query.status == 1)
            {
                status = "Booked";
            }
            else if (query.status == 2)
            {
                status = "Checked out";
            }
            else if (query.status == 3)
            {
                status = "Live in";
            }
            else if (query.status == 4)
            {
                status = "Cancelled";
            }
            else
            {
                status = "No show";
            };

            return Json(new {
                image,
                name,
                address,
                checkIn,
                checkOut,
                status
            });
        }
        public JsonResult InsertReview(string[] values)
        {
            var reservationID = Convert.ToInt32(values[0]);
            var evaluateComment = values[1];
            var evaluatePoint = Convert.ToInt32(values[2]);

            var query = (from re in context.RESERVATIONs
                        join r in context.ROOMs on re.RoomID equals r.RoomID
                        join p in context.PROPERTies on r.PropertyID equals p.PropertyID
                        where re.ReservationID == reservationID
                        select new
                        {
                            re.CustomerID,
                            p.PropertyID
                        }).FirstOrDefault();

            EVALUATE_PROPERTY eva = new EVALUATE_PROPERTY();
            eva.CustomerID = query.CustomerID;
            eva.PropertyID = query.PropertyID;
            eva.Point = evaluatePoint;
            eva.Comment = evaluateComment;
            eva.TimeComment = DateTime.Now;

            context.EVALUATE_PROPERTY.Add(eva);
            context.SaveChanges();
            return Json(new { eva });
        }
        public ActionResult Detail_Booking()
        {
            return View();
        }
        public ActionResult Review_Property()
        {
            return View();
        }
        public JsonResult GetInbox()
        {
            var account = Session["Account"] as ACCOUNT;

            var query = from c in context.CONTACTs
                        where c.userNameReceive == account.Username
                        select new
                        {
                            usernameSend = c.userNameSend,
                            message = c.message
                        };

            List<string> usernameSends = new List<string>();
            List<string> messages = new List<string>();

            foreach (var item in query)
            {
                usernameSends.Add(item.usernameSend);
                messages.Add(item.message);
            }
            return Json(new {
                usernameSends,
                messages
            });
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Reservation()
        {
            return View();
        }
        public ActionResult Review()
        {
            return View();
        }
        public ActionResult GetListReview()
        {
            var account = Session["Account"] as ACCOUNT;

            var query = from a in context.ACCOUNTs
                        join c in context.CUSTOMERs on a.AccountID equals c.AccountID
                        join e in context.EVALUATE_PROPERTY on c.CustomerID equals e.CustomerID
                        join p in context.PROPERTies on e.PropertyID equals p.PropertyID
                        where a.AccountID == account.AccountID
                        select new
                        {
                            id = e.evaPropertyID,
                            image = p.Image_Property,
                            propertyName = p.PropertyName,
                            timeComment = e.TimeComment,
                            point = e.Point,
                            comment = e.Comment
                        };

            List<string> evaluateID = new List<string>();
            List<string> imageProperty = new List<string>();
            List<string> propertyName = new List<string>();
            List<string> timeComment = new List<string>();
            List<string> point = new List<string>();
            List<string> comment = new List<string>();

            foreach (var i in query)
            {
                evaluateID.Add(i.id.ToString());
                imageProperty.Add(i.image);
                propertyName.Add(i.propertyName);
                timeComment.Add(i.timeComment.ToString("MM/dd/yyyy"));
                point.Add(i.point.ToString());
                comment.Add(i.comment);
            }

            return Json(new
            {
                evaluateID,
                imageProperty,
                propertyName,
                timeComment,
                point,
                comment
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail_Review()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SeeDetailReview(string[] values)
        {
            Session["reviewID"] = values[0];

            return Json(new
            {
                msg = values[0]
            }) ;
        }
        [HttpPost]
        public JsonResult GetDetailReview(string[] values)
        {
            int reviewID = Convert.ToInt32(values[0]);
            var query = (from a in context.ACCOUNTs
                        join c in context.CUSTOMERs on a.AccountID equals c.CustomerID
                        join e in context.EVALUATE_PROPERTY on c.CustomerID equals e.CustomerID
                        join p in context.PROPERTies on e.PropertyID equals p.PropertyID
                        join r in context.ROOMs on p.PropertyID equals r.PropertyID
                        join re in context.RESERVATIONs on r.RoomID equals re.RoomID
                        where e.evaPropertyID == reviewID
                        select new { 
                            image = p.Image_Property,
                            propertyName = p.PropertyName,
                            checkIn = re.CheckIn,
                            checkOut = re.CheckOut,
                            point = e.Point,
                            comment = e.Comment,
                            timeComment = e.TimeComment
                        }).FirstOrDefault();

            string image = query.image;
            string propertyName = query.propertyName;
            string checkIn = ((DateTime) query.checkIn).ToString("MM/dd/yyyy");
            string checkOut = ((DateTime) query.checkOut).ToString("MM/dd/yyyy");
            string point = query.point.ToString();
            string comment = query.comment;
            string timeComment = query.timeComment.ToString("MM/dd/yyyy");

            return Json(new
            {
                image,
                propertyName,
                checkIn,
                checkOut,
                point,
                comment,
                timeComment
            });
        }

        public JsonResult GetInfoReservation(string[] values)
        {
            int propertyID = Convert.ToInt32(values[0]);
            int roomID = Convert.ToInt32(values[1]);

            var query = (from r in context.ROOMs
                        join p in context.PROPERTies on r.PropertyID equals p.PropertyID
                        where r.RoomID == roomID && r.PropertyID == propertyID
                        select new
                        {
                            typeRoom = r.TypeOfRoom,
                            roomName = r.RoomName,
                            price = r.Price,
                            image = r.Image_Room,
                            typeProperty = p.TypeName,
                            propertyName = p.PropertyName,
                            address = p.Address_Property,
                            checkInTime = p.CheckInTime,
                            checkOutTime = p.CheckOutTime,
                        }).FirstOrDefault();

            string typeRoom = query.typeRoom;
            string roomName = query.roomName;
            int price = Convert.ToInt32(query.price);
            string image = query.image;
            string typeProperty = query.typeProperty;
            string propertyName = query.propertyName;
            string address = query.address;
            string checkInTime = query.checkInTime;
            string checkOutTime = query.checkOutTime;

            var query2 = (from e in context.EVALUATE_PROPERTY
                          where e.PropertyID == propertyID
                          select e.Point).Average();

            double averagePoint = query2;
            return Json(new {
                typeRoom,
                roomName,
                price,
                image, 
                typeProperty,
                propertyName, 
                address,
                checkInTime,
                checkOutTime,
                averagePoint,
            });
        }

        public JsonResult CreateReservation(string[] values)
        {
            var customer = Session["Customer"] as CUSTOMER;
            bool isSuccess = false;
            if(customer.Status_Account == 1)
            {
                try
                {
                    RESERVATION reservation = new RESERVATION();
                    reservation.CustomerID = customer.CustomerID;
                    reservation.RoomID = Convert.ToInt32(values[0]);
                    reservation.NameCheckInPerson = values[1];
                    reservation.PhoneCheckInPerson = values[2];
                    reservation.CheckIn = DateTime.ParseExact(values[3], "yyyy-MM-dd", null);
                    reservation.CheckOut = DateTime.ParseExact(values[4], "yyyy-MM-dd", null);
                    reservation.Total = Convert.ToDecimal(values[5]);
                    reservation.Status_Reservation = 1;

                    context.RESERVATIONs.Add(reservation);
                    context.SaveChanges();

                    isSuccess = true;
                } catch
                {
                    isSuccess = false;
                }
            }

            return Json(new { isSuccess });
        }

        // GET: CUSTOMER/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CUSTOMER/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CUSTOMER/Create
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

        // GET: CUSTOMER/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CUSTOMER/Edit/5
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

        // GET: CUSTOMER/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CUSTOMER/Delete/5
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
