using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ClassroomController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();
        DayManager dayManager = new DayManager();
        RoomManager roomManager = new RoomManager();
        ClassroomManager classroomManager=new ClassroomManager();

        // GET: /Classroom/
        public ActionResult Save()
        {
            List<Day> days = dayManager.GetAllDays();
            ViewBag.Days = days;
            List<Room> rooms = roomManager.GetAllRooms();
            ViewBag.Rooms = rooms;
            ViewBag.Departments = departmentManager.GetAllDepartments();
            ViewBag.Courses = courseManager.GetAllCourses();
            return View();
        }

        // POST: /ClassRoom/Create
        [HttpPost]
        public ActionResult Save(Classroom classroom)
        {
            string message = classroomManager.Save(classroom);

            ViewBag.Message = message;
            List<Day> days = dayManager.GetAllDays();
            ViewBag.Days = days;
            List<Room> rooms = roomManager.GetAllRooms();
            ViewBag.Rooms = rooms;
            var rr = departmentManager.GetAllDepartments();
            ViewBag.Departments = rr;
            ViewBag.Courses = courseManager.GetAllCourses();
            return View();
        }

        public JsonResult GetClassScheduleByDepartment(int departmentId)
        {
            var courses = courseManager.GetCourseByDepartmentId(departmentId);

            List<object> clsSches = new List<object>();

            foreach (var course in courses)
            {
                var scheduleInfo = classroomManager.GetAllClassSchedulesByDeparmentId(departmentId, course.CourseId);
                if (scheduleInfo == "")
                {
                    scheduleInfo = "Not sheduled yet";
                }


                var clsSch = new
                {
                    courseCode = course.CourseCode,
                    courseName = course.CourseName,
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