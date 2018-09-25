using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class RoomManager
    {
        RoomGateway roomGateway=new RoomGateway();

        public List<Room> GetAllRooms()
        {
            return roomGateway.GetAllRooms();
        }
    }
}