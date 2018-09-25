using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        public List<Departments> GetAllDepartments()
        {
            return aDepartmentGateway.GetAllDepartments();
        }

        public bool IsExitCode(string departmentCode)
        {
            return aDepartmentGateway.IsExitCode(departmentCode);
        }

        public bool IsExitName(string departmentName)
        {
            return aDepartmentGateway.IsExitName(departmentName);
        }
        public string Save(Departments aDepartments)
        {
            if (IsExitCode(aDepartments.DepartmentCode))
            {
                return "Already This Code Exit!!!";
            }
            if (IsExitName(aDepartments.DepartmentName))
            {
                return "Already This Name Exit!!!";
            }
            int rowCount = aDepartmentGateway.Save(aDepartments);
            if (rowCount > 0)
            {
                return "Department Saved";
            }
            return "Department Not Saved";
        }
    }
}