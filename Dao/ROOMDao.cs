using IS220.N12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS220.N12.Dao
{
    public class ROOMDao
    {
        HotelBookingContext context = new HotelBookingContext();
        public bool UpdateRoom(ROOM r)
        {
            try
            {
                ROOM room = context.ROOMs.Find(r.RoomID);
                if (room == null)
                {
                    room = new ROOM();
                    room.RoomName = r.RoomName;
                    room.TypeOfRoom = r.TypeOfRoom;
                    room.BedNum = r.BedNum;
                    room.Price = r.Price;
                    room.Image_Room = r.Image_Room;
                    room.PropertyID = r.PropertyID;

                    context.ROOMs.Add(room);
                    context.SaveChanges();
                } else
                {
                    room.RoomName = r.RoomName;
                    room.TypeOfRoom = r.TypeOfRoom;
                    room.BedNum = r.BedNum;
                    room.Price = r.Price;
                    room.Image_Room = r.Image_Room;
                    room.PropertyID = r.PropertyID;
                    context.SaveChanges();
                }
                return true;
            }
            catch { return false; }
        }
    }
}