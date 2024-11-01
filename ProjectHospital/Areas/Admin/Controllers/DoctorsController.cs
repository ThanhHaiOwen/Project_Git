using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Areas.Admin.Controllers
{
    public class DoctorsController : Controller
    {
        // GET: Admin/Doctors
        public ActionResult ThemBacSi()
        {
            return View();
        }
        public ActionResult DanhSachBacSi()
        {
            return View();
        }
        public ActionResult ChiTietBacSi()
        {
            return View();
        }
        public ActionResult ChinhSuaBacSi()
        {
            return View();
        }
    }
}