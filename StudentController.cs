using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentManager studentManager = new StudentManager();
        DepartmentManager departmentManager = new DepartmentManager();

        // GET: /Student/Create
        [HttpGet]
        public ActionResult Save()
        {
            List<Departments> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        public ActionResult Save(Student aStudent)
        {
            ViewBag.Message = studentManager.Save(aStudent);
            List<Departments> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            ViewBag.StudentInfo = aStudent;

            return View();

        }
    }
}