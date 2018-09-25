using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class DayManager
    {
        DayGateway dayGateway=new DayGateway();

        public List<Day> GetAllDays()
        {
            return dayGateway.GetAllDays();
        }
    }
}