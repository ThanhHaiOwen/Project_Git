using ProjectHospital.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            ViewBag.listBS = db.get("EXEC HienThiThongTinBacSi");
            return View();
        }
        public ActionResult Home()
        {
            if (Session["taikhoan"] == null)
            {
                return RedirectToAction("GiaoDienDangNhap", "Home");
            }
            else
            {
                DataModel db = new DataModel();
                ViewBag.list = db.get("select * from BenhVien");
                return View();
            }
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
        public ActionResult ProfileLayoutBS()
        {
            if (Session["MaTK"] != null)
            {
                string id = Session["MaTK"].ToString();
                DataModel db = new DataModel();

                // Tạo truy vấn SQL hoàn chỉnh với tham số được nối chuỗi (cần cẩn thận với SQL Injection)
                string sqlQuery = "Exec ChiTietBacSi '" + id + "'";

                ViewBag.listBS = db.get(sqlQuery);
                return View();
            }
            else
            {
                return RedirectToAction("GiaoDienDangNhap", "Home");
            }
        }

        [HttpPost]
        public ActionResult UpdateProfileBS(string id, string HoTen, string NgaySinh, string NamKinhNghiem, string MaKhoa, string MaBV, string matkhau, string email, HttpPostedFileBase AnhBacSi)
        {
            try
            {


                // Kiểm tra nếu ảnh đại diện được tải lên
                if (AnhBacSi != null && AnhBacSi.ContentLength > 0)
                {
                    // Lưu ảnh vào thư mục hình ảnh
                    string fileName = Path.GetFileName(AnhBacSi.FileName); // Lấy tên file của ảnh
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/images"), fileName); // Đường dẫn lưu ảnh
                    AnhBacSi.SaveAs(path); // Lưu ảnh vào thư mục
                    DataModel db = new DataModel();

                    // Thực thi stored procedure `ChinhSuaThongTinBacSi` với các tham số truyền vào, bao gồm tên ảnh đại diện
                    db.get("Exec ChinhSuaThongTinBacSi "+ id + ", N'" + HoTen + "', '" + NgaySinh + "', " + NamKinhNghiem + ", " + MaKhoa + ", " + MaBV + ", '" + matkhau + "', N'" + email + "', N'" + AnhBacSi.FileName + "'");

                }

            }
            catch (Exception) { }
            return RedirectToAction("ProfileLayoutBS", "Doctor");
        }
        public ActionResult HienThiThongTinDeCapNhatBS(string id)
        {
            DataModel db = new DataModel();
            ViewBag.listBS = db.get("Exec ChiTietBacSi " + id + ";");
            ViewBag.listBV = db.get("Select * from BenhVien");
            ViewBag.listK = db.get("Select * from Khoa");
            return View();

        }
    }
}