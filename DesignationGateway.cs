using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class DesignationGateway:Gateway
    {
        public List<Designations> GetAllDesignations()
        {
            Query = "Select * FROM Designation";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Designations> designationList = new List<Designations>();
            while (Reader.Read())
            {
                Designations designations = new Designations();
                designations.DesignationId = (int)Reader["DesignationId"];
                designations.DesignationName = Reader["DesignationName"].ToString();
                designationList.Add(designations);
            }
            Reader.Close();
            Connection.Close();
            return designationList;
        }
    }
}