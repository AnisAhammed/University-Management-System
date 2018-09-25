using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ViewClassroomGateway : Gateway
    {

        public List<TempClassSchedule> GetAllClassSchedules()
        {
            List<TempClassSchedule> scheduleList = new List<TempClassSchedule>();
            Query = "SELECT * FROM ScheduleOfClass";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                TempClassSchedule schedule = new TempClassSchedule
                {
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString()),
                    CourseCode = reader["CourseCode"].ToString(),
                    CourseName = reader["CourseName"].ToString(),
                    RoomNo = reader["Room_Name"].ToString(),
                    DayName = reader["Day_Name"].ToString(),
                    StartTime = Convert.ToDateTime(reader["StartTime"].ToString()),
                    EndTime = Convert.ToDateTime(reader["EndTime"].ToString()),
                    Status = Convert.ToBoolean(reader["AllocationStatus"])
                };
                scheduleList.Add(schedule);
            }
            reader.Close();
            return scheduleList;
        }

        public List<Course> GetCourseByDepartmentId(int departmentId)
        {
            Query = "SELECT * FROM Course WHERE DepartmentId='" + departmentId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course();
                course.CourseId = Convert.ToInt32(Reader["CourseId"].ToString());
                course.CourseName = Reader["CourseName"].ToString();
                course.CourseCode = Reader["CourseCode"].ToString();
                course.CourseCredit = (decimal)Reader["CourseCredit"];
                course.DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString());
                course.SemisterId = Convert.ToInt32(Reader["SemisterId"].ToString());
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public List<TempClassSchedule> GetAllClassSchedulesByDeparmentId(int departmentId, int courseId)
        {
            List<TempClassSchedule> scheduleList = new List<TempClassSchedule>();
            Query = "SELECT * FROM ScheduleOfClass WHERE DepartmentId='" + departmentId + "' AND CourseId='" + courseId + "' AND AllocationStatus='" + 1 + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                TempClassSchedule schedule = new TempClassSchedule();

                schedule.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                schedule.CourseCode = reader["CourseCode"].ToString();
                schedule.CourseName = reader["CourseName"].ToString();
                schedule.RoomNo = reader["Room_Name"].ToString();
                schedule.DayName = reader["Day_Name"].ToString();
                schedule.StartTime = Convert.ToDateTime(reader["StartTime"].ToString());
                schedule.EndTime = Convert.ToDateTime(reader["EndTime"].ToString());
                schedule.Status = Convert.ToBoolean(reader["AllocationStatus"]);

                scheduleList.Add(schedule);
            }

            reader.Close();
            Connection.Close();
            return scheduleList;
        }

    }
}