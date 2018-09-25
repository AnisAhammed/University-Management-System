using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class EnrollStudentGateway : Gateway
    {
        public List<EnrollStudent> GetEnrollCourses()
        {
            Query = "SELECT * FROM EnrollCourse";
            Command = new SqlCommand(Query, Connection);
            List<EnrollStudent> enrollStudentList = new List<EnrollStudent>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                EnrollStudent enrollStudent = new EnrollStudent();
                enrollStudent.Id = Convert.ToInt32(Reader["EnrollId"].ToString());
                enrollStudent.StudentId = Convert.ToInt32(Reader["StudentId"].ToString());
                enrollStudent.CourseId = Convert.ToInt32(Reader["CourseId"].ToString());
                enrollStudent.EnrollDate = Convert.ToDateTime(Reader["EnrollDate"].ToString());
                enrollStudent.Status = Convert.ToBoolean(Reader["IsStudentActive"].ToString());

                enrollStudentList.Add(enrollStudent);
            }
            Reader.Close();
            Connection.Close();
            return enrollStudentList;

        }

        public int Insert(EnrollStudent enrollStudent)
        {

            Query = "INSERT INTO EnrollCourse VALUES(@stId,@courseId,@enrollDate,@status)";
            Command=new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@stId", enrollStudent.StudentId);
            Command.Parameters.AddWithValue("@courseId", enrollStudent.CourseId);
            Command.Parameters.AddWithValue("@enrollDate", enrollStudent.EnrollDate.ToShortDateString());
            Command.Parameters.AddWithValue("@status", 1);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public StudentView GetStudentInformationById(int studentId)
        {
            Query = "SELECT * FROM StudentView WHERE StudentId='"+studentId+"'";
            Command=new SqlCommand(Query,Connection);
            StudentView student = null;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                student = new StudentView();
                student.StudentId = Convert.ToInt32(Reader["StudentId"].ToString());
                student.RegNo = Reader["RegNo"].ToString();
                student.Name = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
                student.Address = Reader["Address"].ToString();
                student.DepartmentName = Reader["DepartmentName"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return student;
        }
    }
}