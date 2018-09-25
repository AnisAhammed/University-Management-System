using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class TeacherGateway:Gateway
    {       
        public bool IsExit(string email)
        {
            Query = "SELECT * FROM Teacher WHERE Email='" + email + "'";
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

        public int Save(Teacher aTeachers)
        {
            Query = "INSERT INTO Teacher(TeacherName,Address,ContactNo,Email,DepartmentId,DesignationId,CreditTaken,RemainingCredit) VALUES(@name,@address,@contactNo,@email,@deptId,@desigId,@credit,@RemainingCredit)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("name", aTeachers.TeacherName);

            if (aTeachers.Address != null)
            {
                Command.Parameters.AddWithValue("address", aTeachers.Address);
            }
            else
            {
                Command.Parameters.AddWithValue("address", DBNull.Value);
            }
            
            if (aTeachers.ContactNo != null)
            {
                Command.Parameters.AddWithValue("contactNo", aTeachers.ContactNo);
            }
            else
            {
                Command.Parameters.AddWithValue("contactNo", DBNull.Value);
            }
            Command.Parameters.AddWithValue("email", aTeachers.Email);
            Command.Parameters.AddWithValue("deptId", aTeachers.DepartmentId);
            Command.Parameters.AddWithValue("desigId", aTeachers.DesignationId);
            Command.Parameters.AddWithValue("credit", aTeachers.CreditTaken);
            Command.Parameters.AddWithValue("@RemainingCredit", 0);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public List<Teacher> GetAllTeachers()
        {
            Query = "Select * FROM Teacher";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teacherList = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher teachers = new Teacher();
                teachers.TeacherId = (int)Reader["TeacherId"];
                teachers.TeacherName = Reader["TeacherName"].ToString();
                teachers.Email = Reader["Email"].ToString();
                teachers.ContactNo = Reader["ContactNo"].ToString();
                teachers.Address = Reader["Address"].ToString();
                teachers.DesignationId = Convert.ToInt32(Reader["DesignationId"].ToString());
                teachers.DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString());
                teachers.CreditTaken = (decimal)Reader["CreditTaken"];
                teachers.RemainingCredit = Convert.ToDouble(Reader["RemainingCredit"]);

                teacherList.Add(teachers);
            }
            Reader.Close();
            Connection.Close();
            return teacherList;
        }     
    }
}