using ProjectHospital.Models;
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
            DataModel db = new DataModel();
            ViewBag.listBN = db.get("EXEC HienThiBenhNhan");
            return View();
        }
        public ActionResult ChiTietBenhNhan()
        {
            DataModel db = new DataModel();
            ViewBag.listBN = db.get("EXEC HienThiBenhNhan");
            return View();
        }
        public ActionResult ChinhSuaBenhNhan()
        {
            return View();
        }
    }
}