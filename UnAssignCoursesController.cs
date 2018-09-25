using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;

namespace UniversityManagementSystem.Controllers
{
    public class UnAssignCoursesController : Controller
    {
        UnAssignCoursesManager unAssignCoursesManager = new UnAssignCoursesManager();

        // GET: /UnAssignCourses/
        [HttpGet]
        public ActionResult UnAssignCourses()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnAssignCourses(int? id)
        {
            ViewBag.Message = unAssignCoursesManager.UnAssignCourses();
            return View();
        }
	}
}