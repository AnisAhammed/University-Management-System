using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class EnrollStudentController : Controller
    {
        StudentManager studentManager = new StudentManager();
        CourseManager courseManager = new CourseManager();
        private EnrollStudentManager enrollStudentManager = new EnrollStudentManager();

        [HttpGet]
        public ActionResult EnrollStudent()
        {
            List<Student> students = studentManager.GetAllStudents();
            List<Course> courses = courseManager.GetAllCourses();
            ViewBag.Students = students;
            ViewBag.Courses = courses;
            return View();
        }

        [HttpPost]
        public ActionResult EnrollStudent(EnrollStudent enrollStudent)
        {
            string message = enrollStudentManager.Save(enrollStudent);
            ViewBag.Message = message;
            List<Student> students = studentManager.GetAllStudents();
            List<Course> courses = courseManager.GetAllCourses();
            ViewBag.Students = students;
            ViewBag.Courses = courses;
            return View();
        }

        public JsonResult GetStudentByStudentId(int studentId)
        {
            StudentView student = enrollStudentManager.GetStudentInformationById(studentId);
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByStudentId(int studentId)
        {
            Student aStudent = studentManager.GetAllStudents().ToList().Find(st => st.StudentId == studentId);
            List<Course> courses = courseManager.GetAllCourses().ToList().FindAll(d => d.DepartmentId == aStudent.DepartmentId);
            return Json(courses, JsonRequestBehavior.AllowGet);

        }
    }
}