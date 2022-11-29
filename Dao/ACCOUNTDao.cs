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
        public ACCOUNT signIn(HotelBookingContext context, string gmail, string password)
        {
            var resultQuery = context.ACCOUNTs.Where(a => a.GMAIL.Equals(gmail) 
                                                        && a.Passwords.Equals(password));

            if (resultQuery.Count() > 0)
            {
                var result = from acc in context.ACCOUNTs
                               where acc.GMAIL.Equals(gmail) && acc.Passwords.Equals(password)
                               select new
                               {
                                   username = acc.Username,
                                   role = acc.ROLES
                               };

                ACCOUNT account = new ACCOUNT();
                account.Passwords = password;
                account.GMAIL = gmail;

                foreach (var kq in result)
                {
                    account.Username = kq.username;
                    account.ROLES = kq.role;
                }

                return account;
            }
            return null;
        }
    }
}