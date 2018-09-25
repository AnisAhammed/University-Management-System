using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class DayGateway:Gateway
    {
        public List<Day> GetAllDays()
        {
            Query = "Select * FROM Day";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Day> dayList = new List<Day>();
            while (Reader.Read())
            {
                Day day = new Day();
                day.DayId = (int)Reader["DayId"];
                day.DayName = Reader["DayName"].ToString();
                dayList.Add(day);
            }
            Reader.Close();
            Connection.Close();
            return dayList;
        }
    }
}