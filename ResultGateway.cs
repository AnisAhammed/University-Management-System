using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ResultGateway : Gateway
    {
        public int Insert(Result result)
        {
            Query = "INSERT INTO Result VALUES(@stId,@courseId,@grade,@isStudentActive)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@stId", result.StudentId);
            Command.Parameters.AddWithValue("@courseId", result.CourseId);
            Command.Parameters.AddWithValue("@grade", result.Grade);
            Command.Parameters.AddWithValue("@isStudentActive", 1);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Result> GetAllResults()
        {
            Query = "SELECT * FROM Result";
            Command = new SqlCommand(Query, Connection);
            List<Result> studentResults = new List<Result>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Result studentResult = new Result();
                studentResult.ResultId = Convert.ToInt32(Reader["ResultId"].ToString());
                studentResult.CourseId = Convert.ToInt32(Reader["CourseId"].ToString());
                studentResult.StudentId = Convert.ToInt32(Reader["StudentId"].ToString());
                studentResult.Grade = Reader["Grade"].ToString();
                studentResult.Status = (bool)Reader["IsStudentActive"];

                studentResults.Add(studentResult);
            }
            Reader.Close();
            Connection.Close();
            return studentResults;
        }

        public int UpdateStudentResult(Result result)
        {
            Query = "UPDATE Result SET IsStudentActive=1,Grade='" + result.Grade + "' WHERE StudentId='" +
                                     result.StudentId + "' AND CourseId='" + result.CourseId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int i = Command.ExecuteNonQuery();
            Connection.Close();
            return i;
        }

        public List<Course> GetCoursesTakeByaStudentByStudentId(int courseId)
        {
            List<Course> courses = new List<Course>();
            Query = "Select *FROM Course";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course aCourse = new Course();
                aCourse.CourseId = Convert.ToInt32(Reader["CourseId"].ToString());
                aCourse.CourseName = Reader["Name"].ToString();
                aCourse.CourseCode = Reader["Code"].ToString();
                aCourse.CourseCredit = (decimal)Reader["Credit"];
                aCourse.DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString()); ;
                aCourse.Description = Reader["Descirption"].ToString();
                aCourse.SemisterId = Convert.ToInt32(Reader["SemisterId"].ToString());

                courses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }
    }
}