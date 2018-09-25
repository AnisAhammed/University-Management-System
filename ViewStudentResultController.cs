using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ViewStudentResultController : Controller
    {
        StudentManager studentManager=new StudentManager();
        EnrollStudentManager enrollStudentManager=new EnrollStudentManager();
        StudentResultViewManager studentResultViewManager=new StudentResultViewManager();
        // GET: /ViewStudentResult/
        public ActionResult ViewStudentResult()
        {
            ViewBag.Students = studentManager.GetAllStudents();
            return View();
        }

        public JsonResult GetStudentById(int studentId)
        {
            StudentView student = enrollStudentManager.GetStudentInformationById(studentId);
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStudentResultByStudentId(int studentId)
        {
            List<StudentResultView> studentResults = studentResultViewManager.GetStudentResultByStudentId(studentId);
            return Json(studentResults, JsonRequestBehavior.AllowGet);
        }
	}
}