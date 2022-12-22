using IS220.N12.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS220.N12.Dao
{
    public class PROPERTYDao
    {
        HotelBookingContext context = new HotelBookingContext();
        public bool UpdateInormation(PROPERTY p)
        {
            if (context.ACCOUNTs.Any(x => x.AccountID == p.AccountID))
            {
                var propID = (from prop in context.PROPERTies
                              where prop.AccountID == p.AccountID
                              select prop.PropertyID).FirstOrDefault();

                p.PropertyID = propID;
                try
                {
                    PROPERTY property = context.PROPERTies.Find(p.PropertyID);
                    property.PropertyName = p.PropertyName;
                    property.CheckInTime = p.CheckInTime;
                    property.CheckOutTime = p.CheckOutTime;
                    property.Address_Property = p.Address_Property;
                    property.Detail_Property = p.Detail_Property;
                    property.Phone_Property = p.Phone_Property;
                    property.TypeName = p.TypeName;
                    property.Image_Property = p.Image_Property;
                    property.TypeOfCategory = p.TypeOfCategory;
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    Random rnd = new Random();
                    PROPERTY property = new PROPERTY();
                    property.PropertyName = p.PropertyName;
                    property.CheckInTime = p.CheckInTime;
                    property.CheckOutTime = p.CheckOutTime;
                    property.Address_Property = p.Address_Property;
                    property.Detail_Property = p.Detail_Property;
                    property.Phone_Property = p.Phone_Property;
                    property.TypeName = p.TypeName;
                    property.Image_Property = p.Image_Property;
                    property.AccountID = p.AccountID;
                    property.PlaceID = rnd.Next(1, 101);
                    property.TypeOfCategory = p.TypeOfCategory;

                    context.PROPERTies.Add(property);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IEnumerable<ROOM> ListAllPaging(int propertyID, int page, int pageSize)
        {
            return (from r in context.ROOMs
                    where r.PropertyID == propertyID
                    select r).OrderByDescending(x => x.RoomID).ToPagedList(page, pageSize);
        }
    }
}