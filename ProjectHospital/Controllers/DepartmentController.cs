using Microsoft.Ajax.Utilities;
using ProjectHospital.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public ActionResult HienThiBacSi(string id)
        {
            DataModel db = new DataModel();
            ViewBag.listBS = db.get("Exec LayThongTinBacSiTheoBenhVien " + id + ";");
            return View();

        }

        public ActionResult GDDatLich(string maBS)
        {
            DataModel db = new DataModel();
			var maBN = Session["MaBN"];
			// Kiểm tra session mã bệnh nhân
			if (maBN == null)
			{
				TempData["ErrorMessage"] = "Bạn phải đăng nhập để đặt lịch khám.";
				return RedirectToAction("GiaoDienDangNhap", "Home"); // Nếu chưa đăng nhập, chuyển hướng về trang đăng nhập
			}

			ViewBag.MaBS = maBS; // Lưu mã bác sĩ vào ViewBag
			ViewBag.MaBN = Session["MaBN"]; // Lấy mã bệnh nhân từ session
			return View();
		}

		[HttpPost]
		public ActionResult XuLyDatLich(string MaBN, string MaBS, string NgayHen, string ThoiGianBD, string ThoiGianKT)
		{
			try
			{
				// Chuyển đổi Ngày Hẹn từ chuỗi sang DateTime
				DateTime ngayHenDate = DateTime.Parse(NgayHen); // Chuyển NgayHen thành DateTime (VD: 2024-11-22)

				// Chuyển đổi Thời Gian Bắt Đầu và Thời Gian Kết Thúc từ chuỗi AM/PM sang DateTime
				DateTime thoiGianBD = DateTime.ParseExact(ThoiGianBD, "hh:mm tt", CultureInfo.InvariantCulture);
				DateTime thoiGianKT = DateTime.ParseExact(ThoiGianKT, "hh:mm tt", CultureInfo.InvariantCulture);

				// Kết hợp Ngày Hẹn với Thời Gian Bắt Đầu và Thời Gian Kết Thúc
				thoiGianBD = DateTime.Parse(ngayHenDate.ToString("yyyy-MM-dd") + " " + thoiGianBD.ToString("HH:mm"));
				thoiGianKT = DateTime.Parse(ngayHenDate.ToString("yyyy-MM-dd") + " " + thoiGianKT.ToString("HH:mm"));

				// Gọi stored procedure để lưu lịch khám vào cơ sở dữ liệu
				DataModel db = new DataModel();
				db.get($"Exec DatLichKhambenh '{MaBS}', '{MaBN}','{NgayHen}', '{thoiGianBD}', '{thoiGianKT}'");

				// Redirect đến trang khác sau khi lưu thành công
				return RedirectToAction("Index", "Home");
			}
			catch (Exception ex)
			{
				// Xử lý lỗi nếu có
				TempData["ErrorMessage"] = "Đã xảy ra lỗi: " + ex.Message;
				return RedirectToAction("GDDatLich", "Department");
			}
		}






	}
}