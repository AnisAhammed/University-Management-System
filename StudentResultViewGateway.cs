using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class StudentResultViewGateway : Gateway
    {
        public List<StudentResultView> GetStudentResultByStudentId(int studentId)
        {
            List<StudentResultView> studentResults = new List<StudentResultView>();
            Query = "Select * from StudentResult WHERE StudentId='" + studentId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                StudentResultView studentResult = new StudentResultView();
                studentResult.StudentId = Convert.ToInt32(Reader["StudentId"].ToString());
                studentResult.Code = Reader["CourseCode"].ToString();
                studentResult.Name = Reader["CourseName"].ToString();
                studentResult.Grade = Reader["Grade"].ToString();
                studentResults.Add(studentResult);
            }
            Reader.Close();
            Connection.Close();
            return studentResults;
        }
    }
}