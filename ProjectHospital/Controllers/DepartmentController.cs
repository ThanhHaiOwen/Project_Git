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
				// Chuyển đổi MaBN và MaBS thành kiểu int
				int maBN;
				int maBS;

				// Kiểm tra nếu MaBN và MaBS có thể chuyển thành int không
				if (!int.TryParse(MaBN, out maBN))
				{
					TempData["ErrorMessage"] = "Mã Bệnh Nhân không hợp lệ.";
					return RedirectToAction("GDDatLich", "Department");
				}

				if (!int.TryParse(MaBS, out maBS))
				{
					TempData["ErrorMessage"] = "Mã Bác Sĩ không hợp lệ.";
					return RedirectToAction("GDDatLich", "Department");
				}

				// Chuyển đổi Ngày Hẹn từ chuỗi sang DateTime (chỉ lấy ngày)
				DateTime ngayHenDate = DateTime.Parse(NgayHen); // Chuyển "2024-11-22" thành DateTime

				// Chuyển đổi Thời Gian Bắt Đầu và Thời Gian Kết Thúc từ chuỗi hh:mm tt sang TimeSpan
				TimeSpan thoiGianBD = TimeSpan.ParseExact(ThoiGianBD, @"hh\:mm", CultureInfo.InvariantCulture);
				TimeSpan thoiGianKT = TimeSpan.ParseExact(ThoiGianKT, @"hh\:mm", CultureInfo.InvariantCulture);

				// In ra console để kiểm tra thông tin
				Console.WriteLine($"MaBN: {maBN}, MaBS: {maBS}, NgayHen: {ngayHenDate:yyyy-MM-dd}, ThoiGianBD: {thoiGianBD}, ThoiGianKT: {thoiGianKT}");

				// Gọi stored procedure để lưu lịch khám vào cơ sở dữ liệu
				DataModel db = new DataModel();
				db.get($"EXEC DatLichKham @MaBN = {maBN}, @MaBS = {maBS}, @NgayHen = '{ngayHenDate:yyyy-MM-dd}', @ThoiGianBD = '{thoiGianBD}', @ThoigianKT = '{thoiGianKT}'");

				// Redirect đến trang khác sau khi lưu thành công
				TempData["SuccessMessage"] = "Đặt lịch khám thành công!";
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