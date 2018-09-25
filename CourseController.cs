using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        SemisterManager aSemisterManager=new SemisterManager();
        CourseManager aCourseManager=new CourseManager();
        public ActionResult Save()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Semisters = aSemisterManager.GetAllSemisters();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course aCourse)
        {
            ViewBag.Message = aCourseManager.Save(aCourse);
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Semisters = aSemisterManager.GetAllSemisters();
            return View();
        }
	}
}