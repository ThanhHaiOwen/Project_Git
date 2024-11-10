using ProjectHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Areas.Admin.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Admin/Departments
        public ActionResult DanhSachKhoa()
        {
            DataModel db = new DataModel();
            ViewBag.listK = db.get("EXEC HienThiDanhSachKhoa");
            return View();
        }
        public ActionResult ThemKhoa(string tenkhoa)
        {
            try
            {
                DataModel db = new DataModel();

                // Thực hiện thêm khoa
                var result = db.get("EXEC ThemKhoa N'" + tenkhoa + "';");

                // Kiểm tra kết quả
                if (result != null) // Điều kiện này nên dựa trên kết quả thực thi
                {
                    ViewBag.SuccessMessage = "Thêm khoa thành công!";
                }
                else
                {
                    ViewBag.ErrorMessage = "Đã xảy ra lỗi khi thêm khoa. Vui lòng thử lại.";
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Đã xảy ra lỗi ngoại lệ. Vui lòng thử lại.";
            }

            // Trả về trang thêm khoa với thông báo
            return View();
        }
        public ActionResult XoaKhoa(int id)
        {
            DataModel db = new DataModel();
            db.get("EXEC XoaKhoa " + id); // Thực hiện xóa bệnh viện

            // Thêm thông báo xóa thành công vào TempData
            TempData["SuccessMessage"] = "Xóa khoa thành công!";

            return RedirectToAction("DanhSachKhoa", "Departments", new { area = "Admin" });
        }
        public ActionResult ChiTietKhoa(string id)
        {
            DataModel db = new DataModel();
            ViewBag.listK = db.get("EXEC ChiTietKhoa" + id + ";");
            return View();
        }
        public ActionResult ChinhSuaKhoa(int id, string tenkhoa)
        {
            try
            {
                // Tạo đối tượng DataModel
                DataModel db = new DataModel();

                // Thực hiện gọi thủ tục lưu thông tin khoa
                var result = db.get("EXEC ChinhSuaKhoa " + id + ", N'" + tenkhoa + "';");

                if (result != null)
                {
                    ViewBag.SuccessMessage = "Cập nhật thông tin khoa thành công!";
                }
                else
                {
                    ViewBag.ErrorMessage = "Đã xảy ra lỗi khi cập nhật thông tin khoa. Vui lòng thử lại.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Lỗi: " + ex.Message;
            }

            // Chuyển hướng về trang danh sách khoa
            return RedirectToAction("DanhSachKhoa", "Departments", new { area = "Admin" });
        }



    }
}