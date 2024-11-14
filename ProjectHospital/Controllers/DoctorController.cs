using ProjectHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Docters
        public ActionResult Index()
        {

            DataModel db = new DataModel();
            ViewBag.listBS = db.get("EXEC HienThiBacSi");
            return View();
        }
        public ActionResult TimKiemBacSi(string hoten)
        {
            DataModel db = new DataModel();
            ViewBag.listBS = db.get("EXEC TimBacSi N'" + hoten + "'");

            if (ViewBag.listBS == null ||   ViewBag.listBS.Count == 0)
            {
                ViewBag.Message = "Không tìm thấy bác sĩ nào phù hợp với tên tìm kiếm.";
            }
            else
            {
                ViewBag.listBS =   ViewBag.listBS;
            }

            return View();
        }

    }
}