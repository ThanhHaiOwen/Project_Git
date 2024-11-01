using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Areas.Admin.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Admin/Appointment
        public ActionResult ThemCuocHen()
        {
            return View();
        }
        public ActionResult DanhSachCuocHen()
        {
            return View();
        }
        public ActionResult ChiTietCuocHen()
        {
            return View();
        }
        public ActionResult ChinhSuaCuocHen()
        {
            return View();
        }
    }
}