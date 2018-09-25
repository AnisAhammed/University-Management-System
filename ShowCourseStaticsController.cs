using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ShowCourseStaticsController : Controller
    {
        DepartmentManager departmentManager= new DepartmentManager();
        ShowCourseStaticsManager showCourseStaticsManager = new ShowCourseStaticsManager();

        // GET: /ShowCourseStatics/
        public ActionResult ShowCourseStatics()
        {
            List<Departments> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            //List<CourseView> courseView = showCourseStaticsManager.GetCourseView();
            return View();
        }

        public JsonResult GetCourseInformationByDepartmentId(int departmentId)
        {
            List<CourseView> courseViewModels = showCourseStaticsManager.GetCourseView(departmentId);
            return Json(courseViewModels, JsonRequestBehavior.AllowGet);
        }
	}
}