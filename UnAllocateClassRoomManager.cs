using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;

namespace UniversityManagementSystem.Manager
{
    public class UnAllocateClassRoomManager
    {
        UnAllocateClassRoomGateway unAllocateClassRoomGateway=new UnAllocateClassRoomGateway();
        public String UnAllocateClassRoom()
        {
            if (unAllocateClassRoomGateway.UnAllocateClassRoom() > 0)
            {
                return "UnAllocated Successfully";
            }
            return "Failed to Unallocate";
        }
    }
}