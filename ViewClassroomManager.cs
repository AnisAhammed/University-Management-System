using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ViewClassroomManager
    {
        ViewClassroomGateway viewClassroomGateway=new ViewClassroomGateway();
        CourseGateway courseGateway=new CourseGateway();

        public List<TempClassSchedule> GetAllClassSchedules()
        {
            return viewClassroomGateway.GetAllClassSchedules();
        }

        public List<Course> GetCourseByDepartmentId(int departmentId)
        {
            return viewClassroomGateway.GetCourseByDepartmentId(departmentId);
        }

        public string GetAllClassSchedulesByDeparmentId(int departmentId, int courseId)
        {
            List<TempClassSchedule> classSchedules = viewClassroomGateway.GetAllClassSchedulesByDeparmentId(departmentId, courseId);

            string output = "";

            foreach (var acls in classSchedules)
            {

                if (acls.RoomNo.StartsWith("R"))
                {
                    output += acls.RoomNo + ", " + acls.DayName + ", " + acls.StartTime.ToShortTimeString() + " - " + acls.EndTime.ToShortTimeString() + ";<br />";
                }

                else if (acls.RoomNo.StartsWith("N"))
                {
                    output = acls.RoomNo;

                }


            }

            return output;
        }
    }
}