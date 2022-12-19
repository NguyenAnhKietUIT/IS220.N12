using IS220.N12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS220.N12.Dao
{
    public class CUSTOMERDao
    {
        HotelBookingContext context = new HotelBookingContext();
        public bool UpdateInormation(CUSTOMER c)
        {
            // customer already exists
            if (context.ACCOUNTs.Any(x => x.AccountID == c.AccountID))
            {
                var cusID = (from cus in context.CUSTOMERs
                            where cus.AccountID == c.AccountID
                            select cus.CustomerID).FirstOrDefault();

                c.CustomerID = cusID;
                try
                {
                    CUSTOMER customer = context.CUSTOMERs.Find(c.CustomerID);
                    customer.CustomerName = c.CustomerName;
                    customer.Country = c.Country;
                    customer.Phone = c.Phone;
                    customer.Sex = c.Sex;
                    customer.Status_Account = c.Status_Account;
                    customer.Image_Customer = c.Image_Customer;
                    context.SaveChanges();
                    return true;
                } catch
                {
                    return false;
                }
            }
            // customer does not exists
            else
            {
                try
                {
                    CUSTOMER customer = new CUSTOMER();
                    customer.CustomerName = c.CustomerName;
                    customer.Country = c.Country;
                    customer.Phone = c.Phone;
                    customer.Sex = c.Sex;
                    customer.Status_Account = c.Status_Account;
                    customer.Image_Customer = c.Image_Customer;
                    customer.AccountID = c.AccountID;

                    context.CUSTOMERs.Add(customer);
                    context.SaveChanges();
                    return true;
                } catch
                {
                    return false;
                }
            }
        }

        public bool UpdateStatusReservation(int reservationID)
        {
            try
            {
                RESERVATION reservation = context.RESERVATIONs.Find(reservationID);
                reservation.Status_Reservation = 4;
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}