using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class StudentGateway : Gateway
    {
        public int Insert(Student aStudent)
        {
            Query = "INSERT INTO Student VALUES(@RegNo,@Name,@Email,@ContactNo,@RegisterationDate,@Address,@DepartmentId)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("@RegNo", aStudent.RegNo);
            Command.Parameters.AddWithValue("@Name", aStudent.Name);
            Command.Parameters.AddWithValue("@Email", aStudent.Email.ToLower());
            Command.Parameters.AddWithValue("@ContactNo", aStudent.Contact);
            Command.Parameters.AddWithValue("@RegisterationDate", aStudent.Date.ToShortDateString());
            Command.Parameters.AddWithValue("@Address", aStudent.Address);
            Command.Parameters.AddWithValue("@DepartmentId", aStudent.DepartmentId);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public string GetLastAddedStudentRegistration(string searchKey)
        {
            Query = "SELECT * FROM Student st WHERE RegNo LIKE '%" + searchKey + "%' and StudentId=(select Max(StudentId) FROM Student st WHERE RegNo LIKE '%" + searchKey + "%' )";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Student aStudent = null;
            string regNo = null;
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.Read())
            {
                aStudent = new Student
                {
                    StudentId = Convert.ToInt32(reader["StudentId"].ToString()),
                    Name = reader["Name"].ToString(),
                    RegNo = reader["RegNo"].ToString(),
                    Email = reader["Email"].ToString(),
                    Contact = reader["ContactNo"].ToString(),

                };
                regNo = aStudent.RegNo;
            }          
            reader.Close();
            Connection.Close();
            return regNo;
        }

        public List<Student> GetAllStudents()
        {
            Query = "SELECT * FROM Student";
            Command = new SqlCommand(Query, Connection);
            List<Student> students = new List<Student>();
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student
                {
                    StudentId = Convert.ToInt32(reader["StudentId"].ToString()),
                    RegNo = reader["RegNo"].ToString(),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Address = reader["Address"].ToString(),
                    Contact = reader["ContactNo"].ToString(),
                    Date = Convert.ToDateTime(reader["Date"].ToString()),
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString())
                };
                students.Add(student);
            }
            reader.Close();
            Connection.Close();
            return students;
        }
    }
}