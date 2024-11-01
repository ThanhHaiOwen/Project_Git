using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Areas.Admin.Controllers
{
    public class PatientsController : Controller
    {
        // GET: Admin/Patients
        public ActionResult ThemBenhNhan()
        {
            return View();
        }
        public ActionResult DanhSachBenhNhan()
        {
            return View();
        }
        public ActionResult ChiTietBenhNhan()
        {
            return View();
        }
        public ActionResult ChinhSuaBenhNhan()
        {
            return View();
        }
    }
}