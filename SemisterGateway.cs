using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class SemisterGateway:Gateway
    {
        public List<Semisters> GetAllSemisters()
        {
            Query = "Select * FROM Semister";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semisters> semisterList = new List<Semisters>();
            while (Reader.Read())
            {
                Semisters semisters = new Semisters();
                semisters.SemisterId = (int)Reader["SemisterId"];
                semisters.SemisterName = Reader["SemisterName"].ToString();
                semisterList.Add(semisters);
            }
            Reader.Close();
            Connection.Close();
            return semisterList;
        }
    }
}