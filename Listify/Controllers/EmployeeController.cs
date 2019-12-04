using Listify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Listify.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDB empDB = new EmployeeDB();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(empDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
    }
}