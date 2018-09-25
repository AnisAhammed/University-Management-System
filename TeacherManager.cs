using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway=new TeacherGateway();

        public bool IsExit(string email)
        {
            return aTeacherGateway.IsExit(email);
        }

        public string Save(Teacher aTeachers)
        {
            if (aTeachers.CreditTaken > 0)
            {
                if (IsExit(aTeachers.Email))
                {
                    return "Already This Email Exit!!!";
                }
                int rowCount = aTeacherGateway.Save(aTeachers);
                if (rowCount > 0)
                {
                    return "Teacher Saved";
                }
                return "Teacher Not Saved";
            }
            return "Please Enter positive value";
        }

        public List<Teacher> GetAllTeachers()
        {
            return aTeacherGateway.GetAllTeachers();
        }
        
    }
}