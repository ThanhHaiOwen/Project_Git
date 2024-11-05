using ProjectHospital.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Areas.Admin.Controllers
{
    public class HospitalsController : Controller
    {
        // GET: Admin/Hospitals
        
        public ActionResult ThemBenhVien(string tenbenhvien, string diachi, string sdt, string chuyenve, HttpPostedFileBase anhbenhvien)
        {
            try
            {
                if (anhbenhvien!=null && anhbenhvien.ContentLength > 0)
                {
                    string filename = Path.GetFileName(anhbenhvien.FileName);
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/images"), filename);
                    anhbenhvien.SaveAs(path);
                    DataModel db = new DataModel();

                    // Thực hiện thêm bệnh viện
                    var result = db.get("EXEC ThemBenhVien N'" + tenbenhvien + "', N'" + diachi + "', '" + sdt + "', N'" + chuyenve + "', '" + anhbenhvien.FileName + "';");

                    // Kiểm tra kết quả
                    if (result != null) // Điều kiện này nên dựa trên kết quả thực thi
                    {
                        ViewBag.SuccessMessage = "Thêm bệnh viện thành công!";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Đã xảy ra lỗi khi thêm bệnh viện. Vui lòng thử lại.";
                    }
                }
            }
            catch (Exception) { }


            // Trả về trang thêm bệnh viện với thông báo
            return View();
        }



        public ActionResult DanhSachBenhVien()
        {
            DataModel db = new DataModel();
            ViewBag.listBV = db.get("EXEC DanhSachBenhVien");
            return View();
        }
        public ActionResult ChinhSuaBenhVien(string id, string tenbenhvien, string diachi, string sdt, string chuyenve, HttpPostedFileBase anhbenhvien)
        {
            try
            {
                
                // Xử lý hình ảnh nếu có
                
                if (anhbenhvien != null && anhbenhvien.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(anhbenhvien.FileName);
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/images"), fileName);
                    anhbenhvien.SaveAs(path);
                    // Tạo đối tượng DataModel
                    DataModel db = new DataModel();
                    // Thực hiện cập nhật bệnh viện
                    db.get("EXEC SuaBenhVien N'" + tenbenhvien + "', N'" + diachi + "', '" + sdt + "', N'" + chuyenve + "','"+ anhbenhvien.FileName + "' ," + id + ";");
                }
            }
            catch (Exception) { }
            return RedirectToAction("DanhSachBenhVien", "Hospitals", new { area = "Admin" });

        }

        public ActionResult ChiTietBenhVien(int id)
        {
            DataModel db = new DataModel();
            ViewBag.listBV = db.get("EXEC ChiTietBenhVien " + id + ";");
            return View();
        }
        public ActionResult XoaBenhVien(int id)
        {
            DataModel db = new DataModel();
            db.get("EXEC XoaBenhVien " + id); // Thực hiện xóa bệnh viện

            // Thêm thông báo xóa thành công vào TempData
            TempData["SuccessMessage"] = "Xóa bệnh viện thành công!";

            return RedirectToAction("DanhSachBenhVien", "Hospitals", new { area = "Admin" });
        }
        public ActionResult TimBVUpdate(string id)
        {
            DataModel db = new DataModel();
            ViewBag.listBV = db.get("EXEC ChiTietBenhVien " + id + ";");
            return View();
        }

    }
}