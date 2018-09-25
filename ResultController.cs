using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ResultController : Controller
    {
        StudentManager studentManager = new StudentManager();
        EnrollStudentManager enrollStudentManager=new EnrollStudentManager();
        CourseManager courseManager = new CourseManager();
        ResultManager resultManager = new ResultManager();

        // GET: /Result/
        public ActionResult Save()
        {
            ViewBag.Students = studentManager.GetAllStudents();
            ViewBag.Courses = courseManager.GetAllCourses();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Result result)
        {
            ViewBag.Message = resultManager.Save(result);
            List<Student> students = studentManager.GetAllStudents();
            List<Course> courses = courseManager.GetAllCourses();
            ViewBag.Students = students;
            ViewBag.Courses = courses;
            return View();
        }

        public JsonResult GetStudentById(int studentId)
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