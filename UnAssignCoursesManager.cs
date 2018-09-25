using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;

namespace UniversityManagementSystem.Manager
{
    public class UnAssignCoursesManager
    {
        UnAssignCoursesGateway unAssignCoursesGateway=new UnAssignCoursesGateway();
        public string UnAssignCourses()
        {
            if (unAssignCoursesGateway.UnAssignCourse() > 0)
            {
                return "Unassign Courses Successfully!";
            }
            return "Failed to unassign";
        }
    }
}