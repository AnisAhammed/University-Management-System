using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class DepartmentGateway:Gateway
    {
        public List<Departments> GetAllDepartments()
        {
            Query = "Select * FROM Department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Departments> departmentList = new List<Departments>();
            while (Reader.Read())
            {
                Departments departments = new Departments();
                departments.DepartmentId = (int)Reader["DepartmentId"];
                departments.DepartmentName = Reader["DepartmentName"].ToString();
                departments.DepartmentCode = Reader["DepartmentCode"].ToString();
                departmentList.Add(departments);
            }
            Reader.Close();
            Connection.Close();
            return departmentList;
        }

        public bool IsExitCode(string departmentCode)
        {
            Query = "SELECT * FROM Department WHERE DepartmentCode='" + departmentCode + "'";
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

        public bool IsExitName(string departmentName)
        {
            Query = "SELECT * FROM Department WHERE DepartmentName='" + departmentName + "'";
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

        public int Save(Departments aDepartments)
        {
            Query = "INSERT INTO Department(DepartmentName,DepartmentCode) VALUES(@name,@code)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("name", aDepartments.DepartmentName);
            Command.Parameters.AddWithValue("code", aDepartments.DepartmentCode);            
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }


    }
}