using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ClassroomGateway : Gateway
    {
        public int Save(Classroom classroom)
        {
            Query =
                "INSERT INTO Classroom(DepartmentId,CourseId,RoomId,DayId,StartTime,Endtime,AllocationStatus) VALUES(@deptId,@courseId,@roomId,@dayId,@StartTime,@endTime,@allocationStatus)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@deptId", classroom.DepartmentId);
            Command.Parameters.AddWithValue("@courseId", classroom.CourseId);
            Command.Parameters.AddWithValue("@roomId", classroom.RoomId);
            Command.Parameters.AddWithValue("@dayId", classroom.DayId);
            Command.Parameters.AddWithValue("@startTime", classroom.StartTime.ToShortTimeString());
            Command.Parameters.AddWithValue("@endTime", classroom.Endtime.ToShortTimeString());
            Command.Parameters.AddWithValue("@allocationStatus", 1);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Classroom> GetClassSchedulByStartAndEndingTime(int roomId, int dayId, DateTime startTime, DateTime endTime)
        {
            Query = "Select * from Classroom Where DayId=" + dayId + " AND RoomId=" + roomId + " AND AllocationStatus=" + 1;
            Command=new SqlCommand(Query,Connection);
            List<Classroom> tempClassSchedules = new List<Classroom>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Classroom temp = new Classroom
                {
                    ClassroomId = Convert.ToInt32(Reader["ClassroomId"].ToString()),
                    DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString()),
                    CourseId = Convert.ToInt32(Reader["CourseId"].ToString()),
                    RoomId = Convert.ToInt32(Reader["RoomId"].ToString()),
                    DayId = Convert.ToInt32(Reader["DayId"].ToString()),
                    StartTime = Convert.ToDateTime(Reader["StartTime"].ToString()),
                    Endtime = Convert.ToDateTime(Reader["EndTime"].ToString())

                };
                tempClassSchedules.Add(temp);
            }
            Reader.Close();
            Connection.Close();
            return tempClassSchedules;

        }


        public List<TempClassSchedule> GetAllClassSchedulesByDeparmentId(int departmentId, int courseId)
        {
            List<TempClassSchedule> scheduleList = new List<TempClassSchedule>();
            Query = "SELECT * FROM ScheduleOfClass WHERE DepartmentId='" + departmentId + "' AND CourseId='" + courseId + "' AND AllocationStatus='" + 1 + "'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                TempClassSchedule schedule = new TempClassSchedule
                {

                    DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString()),
                    CourseCode = Reader["Code"].ToString(),
                    CourseName = Reader["Name"].ToString(),
                    RoomNo = Reader["Room_Name"].ToString(),
                    DayName = Reader["Day_Name"].ToString(),
                    StartTime = Convert.ToDateTime(Reader["StartTime"].ToString()),
                    EndTime = Convert.ToDateTime(Reader["EndTime"].ToString()),
                    Status = Convert.ToBoolean(Reader["AllocationStatus"])
                };

                scheduleList.Add(schedule);
            }

            Reader.Close();
            Connection.Close();
            return scheduleList;

        }
    }
}