using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ShowCourseStaticsManager
    { 
        ShowCourseStaticsGateway showCourseStaticsGateway=new ShowCourseStaticsGateway();

        public List<CourseView> GetCourseView(int departmentId)
        {
            return showCourseStaticsGateway.GetCourseView(departmentId);
        }
    }
}