using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class CourseManager
    {
        CourseGateway aCourseGateway=new CourseGateway();
        public List<Course> GetAllCourses()
        {
            return aCourseGateway.GetAllCourses();
        }

        public bool IsExitCode(string courseCode)
        {
            return aCourseGateway.IsExitCode(courseCode);
        }
        public bool IsExitName(string courseName)
        {
            return aCourseGateway.IsExitName(courseName);
        }

        public string Save(Course aCourses)
        {
            if (aCourses.CourseCode.Length >= 5)
            {
                if (IsExitCode(aCourses.CourseCode))
                {
                    return "Already This Course Code Exit!!!";
                }
                if (IsExitName(aCourses.CourseName))
                {
                    return "Already This Course Name Exit!!!";
                }
                int rowCount = aCourseGateway.Save(aCourses);
                if (rowCount > 0)
                {
                    return "Course Saved";
                }
                return "Course Not Saved";
            }
            return "Please Enter At least 5 characters";
        }


        public List<Course> GetCourseByDepartmentId(int departmentId)
        {
            return aCourseGateway.GetCourseByDepartmentId(departmentId);
        }
    }
}