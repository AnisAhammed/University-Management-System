using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;

namespace UniversityManagementSystem.Controllers
{
    public class ViewDepartmentController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        public ActionResult ViewDepartment()
        {
            ViewBag.ViewDepartments = aDepartmentManager.GetAllDepartments();
            return View();
        }
	}
}