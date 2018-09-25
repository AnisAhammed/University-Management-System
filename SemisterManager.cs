using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class SemisterManager
    {
        SemisterGateway aSemisterGateway = new SemisterGateway();
        public List<Semisters> GetAllSemisters()
        {
            return aSemisterGateway.GetAllSemisters();
        }
    }
}