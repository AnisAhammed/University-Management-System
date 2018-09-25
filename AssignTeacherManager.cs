using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class AssignTeacherManager
    {
        AssignTeacherGateway assignGateway = new AssignTeacherGateway();

        public string Save(AssignTeachers assignTeachers)
        {

            AssignTeachers courseAssign = GetAllAssignTeachers().ToList().Find(ca => ca.CourseId == assignTeachers.CourseId && ca.Status);

            if (courseAssign == null)
            {
                if (assignGateway.Save(assignTeachers) > 0)
                {
                    return "Assigned successfully";
                }
                return "Failed saved";
            }

            return "Overlaping not allowed!";
        }


        public List<AssignTeachers> GetAllAssignTeachers()
        {
            return assignGateway.GetAllAssignTeachers();
        } 
    }
}