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
										)
		{
			////tạo biến để lưu giá trị
			DataModel db = new DataModel();
			ViewBag.list = db.get("Exec THEMTAIKHOANBenhNhan N'" + HoVaTen + "','" + email + "','" + matkhau + "'");
			if (ViewBag.list.Count > 0 && ViewBag.list != null)
			{
				//Session["taikhoan"] = ViewBag.list[0];
				return RedirectToAction("GiaoDienDangNhap", "Home");
			}
			else
			{
				// Sử dụng TempData để lưu thông báo lỗi
				TempData["ErrorMessage"] = "Đăng ký thất bại, hãy thử lại.";
				return RedirectToAction("GiaoDienDangKy", "Home");
			}

		}
		

		[HttpPost]
		public ActionResult xuLyDangNhapchobenhNhan(string email,
										string matkhau
										)
		{
			DataModel db = new DataModel();
			ViewBag.list = db.get("Exec DangNhapTaiKhoanbenhNhan '"+email+"','"+matkhau+"'");
			if (ViewBag.list.Count > 0)
			{
				Session["taikhoan"] = ViewBag.list[0];
				return RedirectToAction("Index", "Home");
			}
			else
			{
				// Sử dụng TempData để lưu thông báo lỗi
				TempData["ErrorMessage"] = "Mật khẩu sai hoặc tài khoản không tồn tại.";
				return RedirectToAction("GiaoDienDangNhap", "Home");
			}
		}

	}
}