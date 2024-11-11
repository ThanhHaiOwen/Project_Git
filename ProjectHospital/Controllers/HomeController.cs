using ProjectHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Data.SqlClient;
using System.IO;

namespace ProjectHospital.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (Session["taikhoan"] == null)
			{
				return RedirectToAction("GiaoDienDangNhap", "Home");
			}
			else { DataModel db = new DataModel();
			ViewBag.list = db.get("select * from BenhVien");
			return View();
			}
			
		}

		public ActionResult GiaoDienDangNhap()
		{
			return View();
		}
		public ActionResult GiaoDienDangKyChoBacSi()
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
		public ActionResult xuLyDangKychoBacSi(
										string email,
										string matkhau
										)
		{
			////tạo biến để lưu giá trị
			DataModel db = new DataModel();
			ViewBag.list = db.get("Exec THEMTAIKHOANBacSi '" + email + "','" + matkhau + "'");
			if (ViewBag.list.Count > 0 && ViewBag.list != null)
			{
				//Session["taikhoan"] = ViewBag.list[0];
				return RedirectToAction("GiaoDienDangNhap", "Home");
			}
			else
			{
				// Sử dụng TempData để lưu thông báo lỗi
				TempData["ErrorMessage"] = "Đăng ký thất bại, hãy thử lại.";
				return RedirectToAction("GiaoDienDangKyChoBacSi", "Home");
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
				Session["Matk"]=user[0];

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

		public ActionResult ProfileLayout()
		{
			if (Session["MaTK"] != null)
			{
				string id = Session["MaTK"].ToString();
				DataModel db = new DataModel();

				// Tạo truy vấn SQL hoàn chỉnh với tham số được nối chuỗi (cần cẩn thận với SQL Injection)
				string sqlQuery = "Exec ProfileLayout '" + id + "'";

				ViewBag.list = db.get(sqlQuery);
				return View();
			}
			else
			{
				return RedirectToAction("GiaoDienDangNhap", "Home");
			}
		}


		public ActionResult HienThiThongTinDeCapNhat(string id)
		{
			DataModel db = new DataModel();
			ViewBag.list = db.get("Exec ProfileLayout " + id + ";");
			return View();

		}

		[HttpPost]
		public ActionResult UpdateProfile(string id,string HoTen, string NgaySinh, string GioiTinh, string DiaChi, string matkhau)
		{
			try
			{
				DataModel db=new DataModel();
				db.get("Exec ChinhSuaTT " + id + ",N'" + HoTen + "','" + NgaySinh + "','" + GioiTinh + "', N'" + DiaChi + "', '"+matkhau+"'");
			}
			catch(Exception) { }
			return RedirectToAction("ProfileLayout", "Home");
		}

		public ActionResult GiaoDienNapTien(string id)
		{
			DataModel db= new DataModel();
			ViewBag.list=db.get("select * from PhuongThucThanhToan");
			ViewBag.listpf = db.get("Exec ProfileLayout " + id + ";");
			return View();
		}

		[HttpPost]
		public ActionResult XuLyNapTien(string id, string SoTien, string MaThanhToan)
		{
			try
			{
				DataModel db = new DataModel();
				db.get("Exec CapNhatTienNap " + id + ", "+SoTien +" ," + MaThanhToan + "");
			}
			catch (Exception) { }
			return RedirectToAction("Index", "Home");
		}







	}
} 

	
