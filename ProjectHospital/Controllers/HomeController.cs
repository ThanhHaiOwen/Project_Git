using ProjectHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult GiaoDienDangNhap() 
		{
			return View();
		}


		public ActionResult GiaoDienDangKy()
		{
			return View();
		}

		[HttpPost]
		public ActionResult xuLyDangKychobenhNhan(string HoVaTen,
										string email,
										string matkhau
										) { 
			DataModel db = new DataModel();
			ViewBag.list = db.get("Exec THEMTAIKHOANBenhNhan N'" + HoVaTen + "','" + email + "','" + matkhau + "'");
			if (ViewBag.list.Count > 0)
			{
				Session["taikhoan"] = ViewBag.list[0];
				return RedirectToAction("GiaoDienDangKy", "Home");
			}
			else
			{
				return RedirectToAction("GiaoDienDangNhap", "Home");
			}
		}

	}
}