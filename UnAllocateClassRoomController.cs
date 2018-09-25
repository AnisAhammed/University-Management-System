using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;

namespace UniversityManagementSystem.Controllers
{
    public class UnAllocateClassRoomController : Controller
    {
        UnAllocateClassRoomManager unAllocateClassRoomManager = new UnAllocateClassRoomManager();
        
        // GET: /UnAllocateClassRoom/
        [HttpGet]
        public ActionResult UnAllocateClassRoom()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnAllocateClassRoom(int? id)
        {
            ViewBag.Message = unAllocateClassRoomManager.UnAllocateClassRoom();
            return View();
        }
	}
}