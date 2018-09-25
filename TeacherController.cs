using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        TeacherManager aTeacherManager=new TeacherManager();
        DepartmentManager aDepartmentManager=new DepartmentManager();
        DesignationManager aDesignationManager=new DesignationManager();
        public ActionResult Save()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Designations = aDesignationManager.GetAllDesignations();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher aTeacher)
        {
            ViewBag.Message = aTeacherManager.Save(aTeacher);
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Designations = aDesignationManager.GetAllDesignations();
            return View();
        }
	}
}