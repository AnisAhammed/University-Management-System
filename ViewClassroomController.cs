using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ViewClassroomController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        ViewClassroomManager viewClassroomManager = new ViewClassroomManager();
        CourseManager courseManager = new CourseManager();

        private List<TempClassSchedule> classrooms;
        // GET: /ViewClassroom/
        public ActionResult ViewClassroom()
        {
            ViewBag.Departments = departmentManager.GetAllDepartments();
             classrooms= viewClassroomManager.GetAllClassSchedules();
            ViewBag.ClassSchedule = classrooms;
            return View();
        }

        public JsonResult GetClassScheduleByDepartment(int departmentId)
        {
            var courses = viewClassroomManager.GetCourseByDepartmentId(departmentId);

            List<Object> clsSches = new List<Object>();

            foreach (var course in courses)
            {
                var scheduleInfo = viewClassroomManager.GetAllClassSchedulesByDeparmentId(departmentId, course.CourseId);
                if (scheduleInfo == "")
                {
                    scheduleInfo = "Not sheduled yet";
                }

                var clsSch = new
                {
                    Code = course.CourseCode,
                    Name = course.CourseName,
                    ScheduleInfo = scheduleInfo
                };
                clsSches.Add(clsSch);
            }
            return Json(clsSches, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            List<Course> courses = courseManager.GetAllCourses();
            var courseList = courses.ToList().FindAll(c => c.DepartmentId == departmentId);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
    }
}