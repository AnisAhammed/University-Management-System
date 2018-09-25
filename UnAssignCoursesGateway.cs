using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Gateway
{
    public class UnAssignCoursesGateway : Gateway
    {
        public int UnAssignCourse()
        {
            Query = "UPDATE Assign SET IsActive=0";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            UpdateTeacherInformation();
            int a = ResetStudentResult();
            int i = UnAssignStudentCourse();
            Connection.Close();
            return i;
        }

        public int UpdateTeacherInformation()
        {
            Query = "UPDATE Teacher SET RemainingCredit=0";
            Command=new SqlCommand(Query,Connection);
            int row = Command.ExecuteNonQuery();
            return row;
        }

        private int ResetStudentResult()
        {
            Query = "UPDATE Result SET IsStudentActive=0";
            int rowCount = Command.ExecuteNonQuery();
            return rowCount;
        }

        private int UnAssignStudentCourse()
        {
            Query = "UPDATE EnrollCourse SET IsStudentActive=0";
            int rowCnt = Command.ExecuteNonQuery();
            return rowCnt;
        }

    }
}