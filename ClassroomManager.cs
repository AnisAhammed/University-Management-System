using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ClassroomManager
    {
        ClassroomGateway classroomGateway = new ClassroomGateway();
        public String Save(Classroom classroom)
        {
            if (classroom.StartTime > classroom.Endtime)
            {
                return "To time can't less than From time )";
            }
            bool isTimeScheduleValid = IsTimeScheduleValid(classroom.RoomId, classroom.DayId, classroom.StartTime, classroom.Endtime);

            if (isTimeScheduleValid != true)
            {

                if (classroomGateway.Save(classroom) > 0)
                {
                    return "Saved Successfully !";
                }
                return "Failed to save";

            }
            return "Overlapping not allowed";
        }

        private bool IsTimeScheduleValid(int roomId, int dayId, DateTime startTime, DateTime endTime)
        {
            List<Classroom> schedule = classroomGateway.GetClassSchedulByStartAndEndingTime(roomId, dayId, startTime, endTime);
            foreach (var sd in schedule)
            {
                if ((sd.DayId == dayId && roomId == sd.RoomId) &&
                                 (startTime < sd.StartTime && endTime > sd.StartTime)
                                 || (startTime < sd.StartTime && endTime > sd.StartTime) ||
                                 (startTime == sd.StartTime) || (sd.StartTime < startTime && sd.Endtime > startTime)
                                 )
                {
                    return true;
                }

            }
            return false;

        }


        public string GetAllClassSchedulesByDeparmentId(int departmentId, int courseId)
        {
            List<TempClassSchedule> classSchedules = classroomGateway.GetAllClassSchedulesByDeparmentId(departmentId, courseId);

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