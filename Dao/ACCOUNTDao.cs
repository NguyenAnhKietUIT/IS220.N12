using IS220.N12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS220.N12.Dao
{
    public class ACCOUNTDao
    {
        public ACCOUNT Login(HotelBookingContext context, string gmail, string password, int role)
        {
            var resultQuery = context.ACCOUNTs.Where(a => a.GMAIL.Equals(gmail) 
                                                        && a.Passwords.Equals(password)
                                                        && a.ROLES.Equals(role));

            if (resultQuery.Count() > 0)
            {
                var username = from acc in context.ACCOUNTs
                               where acc.GMAIL.Equals(gmail) && acc.Passwords.Equals(password) && acc.ROLES.Equals(role)
                               select acc.Username;

                ACCOUNT account = new ACCOUNT();
                account.Username = username.FirstOrDefault();
                account.Passwords = password;
                account.GMAIL = gmail;
                account.ROLES = role;

                return account;
            }
            return null;
        }
    }
}