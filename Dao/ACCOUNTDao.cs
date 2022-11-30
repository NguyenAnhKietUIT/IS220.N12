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
        public ACCOUNT signIn(HotelBookingContext context, string username, string password)
        {
            var resultQuery = context.ACCOUNTs.Where(a => a.Username.Equals(username) 
                                                        && a.Passwords.Equals(password));

            if (resultQuery.Count() > 0)
            {
                var result = from acc in context.ACCOUNTs
                               where acc.Username.Equals(username) && acc.Passwords.Equals(password)
                               select new
                               {
                                   gmail = acc.GMAIL,
                                   role = acc.ROLES
                               };

                ACCOUNT account = new ACCOUNT();
                account.Passwords = password;
                account.Username = username;

                foreach (var kq in result)
                {
                    account.GMAIL = kq.gmail;
                    account.ROLES = kq.role;
                }

                return account;
            }
            return null;
        }
    }
}