using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ShowCourseStaticsGateway : Gateway
    {
        public List<CourseView> GetCourseView(int departmentId)
        {
            Query = "Select * FROM CourseView Where DepartmentId='" + departmentId + "'";
            //Command.CommandType = CommandType.StoredProcedure;
            Command=new SqlCommand(Query,Connection);
            List<CourseView> courseView = new List<CourseView>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                CourseView course = new CourseView();
                course.DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString());
                course.Name = Reader["Name"].ToString();
                course.Code = Reader["Code"].ToString();
                course.Semester = Reader["Semester"].ToString();
                course.Teacher = Reader["Teacher"].ToString();

                courseView.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courseView;
        }
    }
}