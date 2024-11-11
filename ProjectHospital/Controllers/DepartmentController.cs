using ProjectHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("select * from BenhVien");
            return View();
        }
    }
}