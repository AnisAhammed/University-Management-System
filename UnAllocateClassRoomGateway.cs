using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Gateway
{
    public class UnAllocateClassRoomGateway : Gateway
    {
        public int UnAllocateClassRoom()
        {
            Query = "UPDATE Classroom SET AllocationStatus=0";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }
    }
}