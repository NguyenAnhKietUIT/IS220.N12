using IS220.N12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace IS220.N12.Dao
{
    public class ACCOUNTDao
    {
        private HotelBookingContext context = new HotelBookingContext();
        public ACCOUNT signIn(string username, string password)
        {
            var resultQuery = context.ACCOUNTs.Where(a => a.Username.Equals(username) 
                                                        && a.Passwords.Equals(password));

            if (resultQuery.Count() > 0)
            {
                var result = from acc in context.ACCOUNTs
                               where acc.Username.Equals(username) && acc.Passwords.Equals(password)
                               select new
                               {
                                   id = acc.AccountID,
                                   gmail = acc.GMAIL,
                                   role = acc.ROLES
                               };

                ACCOUNT account = new ACCOUNT();
                account.Passwords = password;
                account.Username = username;

                foreach (var kq in result)
                {
                    account.AccountID = kq.id;
                    account.GMAIL = kq.gmail;
                    account.ROLES = kq.role;
                }

                return account;
            }
            return null;
        }

        public bool signUp(string[] values)
        {
            try
            {
                ACCOUNT account = new ACCOUNT();
                account.Username = values[0];
                account.GMAIL = values[1];
                account.Passwords = values[2];
                account.ROLES = Convert.ToInt32(values[3]);

                context.ACCOUNTs.Add(account);
                context.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<ACCOUNT> ListAllPaging(int page, int pageSize)
        {
            return context.ACCOUNTs.OrderByDescending(x => x.AccountID).ToPagedList(page, pageSize);
        }
    }
}