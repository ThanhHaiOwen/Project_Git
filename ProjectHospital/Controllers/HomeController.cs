﻿using ProjectHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace ProjectHospital.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (Session["taikhoan"]== null)
			{
				return RedirectToAction("GiaoDienDangNhap","Home");
			}
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
		public ActionResult xuLyDangKychobenhNhan(
										string email,
										string matkhau
										)
		{
			////tạo biến để lưu giá trị
			DataModel db = new DataModel();
			ViewBag.list = db.get("Exec THEMTAIKHOANBenhNhan '" + email + "','" + matkhau + "'");
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
			ViewBag.list = db.get("Exec DangNhapTaiKhoanbenhNhan '" + email + "','" + matkhau + "'");
			if (ViewBag.list.Count > 0)
			{
				// Lấy hàng đầu tiên
				ArrayList user = (ArrayList)ViewBag.list[0]; // Lấy hàng đầu tiên
				Session["taikhoan"] = user; // Lưu hàng vào session
				Session["Vaitro"] = user[4];

				int VaiTro = Convert.ToInt32(user[4]);
				if (VaiTro == 0)
				{
					return RedirectToAction("Index", "Home");
				}
				if (VaiTro == 1) {
					return RedirectToAction("index", "HomeAdmin",new { area = "Admin"});
				}
				else
				{
					return RedirectToAction("ChinhSuaCuocHen", "Appointment", new { area = "Admin" });
				}
				
			}
			else
			{
				// Sử dụng TempData để lưu thông báo lỗi
				TempData["ErrorMessage"] = "Mật khẩu sai hoặc tài khoản không tồn tại.";
				return RedirectToAction("GiaoDienDangNhap", "Home");
			}
		}

		public ActionResult xuLyDangXuat()    
		{
			Session.Remove("taikhoan");
			return RedirectToAction("Index", "Home");
		}
	}
} 

	
