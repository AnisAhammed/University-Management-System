using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class AssignTeacherController : Controller
    {
        TeacherManager aTeacherManager = new TeacherManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        CourseManager aCourseManager=new CourseManager();
        AssignTeacherManager assignTeacherManager=new AssignTeacherManager();

        public ActionResult Save()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Teachers = aTeacherManager.GetAllTeachers();
            ViewBag.Courses = aCourseManager.GetAllCourses();
            return View();
        }

        [HttpPost]
        public ActionResult Save(AssignTeachers assigns)
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Teachers = aTeacherManager.GetAllTeachers();
            ViewBag.Courses = aCourseManager.GetAllCourses();
            ViewBag.Message = assignTeacherManager.Save(assigns);
            return View();
        }

        public JsonResult GetTeachersByDepartmentId(int departmentId)
        {
            List<Teacher> teachers = aTeacherManager.GetAllTeachers();
            var teacherList = teachers.ToList().FindAll(t => t.DepartmentId == departmentId);
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            List<Course> courses = aCourseManager.GetAllCourses();
            var courseList = courses.ToList().FindAll(c => c.DepartmentId == departmentId);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeacherById(int teacherId)
        {
            List<Teacher> teachers = aTeacherManager.GetAllTeachers();
            Teacher aTeacher = teachers.ToList().Find(t => t.TeacherId == teacherId);
            return Json(aTeacher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseById(int courseId)
        {
            List<Course> courses = aCourseManager.GetAllCourses();
            Course aCourse = courses.ToList().Find(c => c.CourseId == courseId);
            return Json(aCourse, JsonRequestBehavior.AllowGet);
        }
	}
}