using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class CourseGateway : Gateway
    {
        public List<Course> GetAllCourses()
        {
            Query = "Select * FROM Course";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            while (Reader.Read())
            {
                Course courses = new Course();
                courses.CourseId = (int)Reader["CourseId"];
                courses.CourseName = Reader["CourseName"].ToString();
                courses.CourseCode = Reader["CourseCode"].ToString();
                courses.CourseCredit = Convert.ToDecimal(Reader["CourseCredit"]);
                if (courses.Description != null)
                {
                    Command.Parameters.AddWithValue("description", courses.Description);
                }
                else
                {
                    Command.Parameters.AddWithValue("description", DBNull.Value);
                }
                courses.DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString());
                courses.SemisterId = Convert.ToInt32(Reader["SemisterId"].ToString());
                courseList.Add(courses);
            }
            Reader.Close();
            Connection.Close();
            return courseList;
        }

        public bool IsExitCode(string courseCode)
        {
            Query = "SELECT * FROM Course WHERE CourseCode='" + courseCode + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Connection.Close();
                return true;
            } Connection.Close();
            return false;
        }

        public bool IsExitName(string courseName)
        {
            Query = "SELECT * FROM Course WHERE CourseName='" + courseName + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Connection.Close();
                return true;
            } Connection.Close();
            return false;
        }

        public int Save(Course aCourses)
        {
            Query = "INSERT INTO Course(CourseName,CourseCode,CourseCredit,Description,DepartmentId,SemisterId) VALUES(@name,@code,@credit,@description,@deptId,@semisterId)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("name", aCourses.CourseName);
            Command.Parameters.AddWithValue("code", aCourses.CourseCode);
            Command.Parameters.AddWithValue("credit", aCourses.CourseCredit);
            Command.Parameters.AddWithValue("description", aCourses.Description);
            Command.Parameters.AddWithValue("deptId", aCourses.DepartmentId);
            Command.Parameters.AddWithValue("semisterId", aCourses.SemisterId);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;

        }


        public List<Course> GetCourseByDepartmentId(int departmentId)
        {
            Query = "SELECT * FROM Course WHERE DepartmentId='" + departmentId + "'";
            Command = new SqlCommand(Query, Connection);
            List<Course> courses = new List<Course>();
            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Course course = new Course
                {
                    CourseId = Convert.ToInt32(Reader["CourseId"].ToString()),
                    CourseName = Reader["CourseName"].ToString(),
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseCredit = (decimal)Reader["CourseCredit"],
                    Description = Reader["Descirption"].ToString(),
                    DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString()),
                    SemisterId = Convert.ToInt32(Reader["SemisterId"].ToString())

                };
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }
    }
}