using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        public ActionResult Save()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Save(Departments aDepartments)
        {
            ViewBag.Message = aDepartmentManager.Save(aDepartments);
            return View();
        }
	}
}