using IS220.N12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS220.N12.Dao
{
    public class RESERVATIONDao
    {
        HotelBookingContext context = new HotelBookingContext();
        public bool UpdateStatus(int reservationID, int status)
        {
            try
            {
                RESERVATION reservation = context.RESERVATIONs.Find(reservationID);
                reservation.Status_Reservation = status;
                context.SaveChanges();
                return true;
            } catch
            {
                return false;
            }
        }
    }
}