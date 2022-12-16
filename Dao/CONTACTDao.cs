using IS220.N12.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS220.N12.Dao
{
    public class CONTACTDao
    {
        HotelBookingContext context = new HotelBookingContext();
        public IEnumerable<CONTACT> ListAllPaging(int page, int pageSize)
        {
            return context.CONTACTs.OrderByDescending(x => x.ContactID).ToPagedList(page, pageSize);
        }
    }
}