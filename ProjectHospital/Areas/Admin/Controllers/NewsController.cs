using ProjectHospital.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        // GET: Admin/News
        public ActionResult ThemTinTuc(string tieude, string noidung, string ngaydang, string tacgia, HttpPostedFileBase anhminhhoa)
        {
            try
            {
                if (anhminhhoa!=null && anhminhhoa.ContentLength > 0)
                {
                    string filename = Path.GetFileName(anhminhhoa.FileName);
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/images"), filename);
                    anhminhhoa.SaveAs(path);
                    DataModel db = new DataModel();

                    // Thực hiện thêm bệnh viện
                    var result = db.get("EXEC ThemTinTuc N'" + tieude + "', N'" + noidung + "', '" + ngaydang + "', N'" + tacgia + "', '" + anhminhhoa.FileName + "';");

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
        public ActionResult DanhSachTinTuc()
        {
            DataModel db = new DataModel();
            ViewBag.listTT = db.get("SELECT * FROM TinTuc");
            return View();
            
        }
        public ActionResult ChiTietTinTuc(int id)
        {
            DataModel db = new DataModel();
            ViewBag.listTT = db.get("EXEC ChiTietTinTuc " + id + ";");
            return View();
        }
        public ActionResult XoaTinTUc(int id)
        {
            DataModel db = new DataModel();
            db.get("EXEC XoaTinTuc " + id); // Thực hiện xóa bệnh viện

            // Thêm thông báo xóa thành công vào TempData
            TempData["SuccessMessage"] = "Xóa bệnh viện thành công!";

            return RedirectToAction("DanhSachTinTuc", "News", new { area = "Admin" });
        }
        public ActionResult TimTinTucUpdate(string id)
        {
            DataModel db = new DataModel();
            ViewBag.listTT = db.get("EXEC ChiTietTinTuc " + id + ";");
            return View();
        }
        [HttpPost]  
        public ActionResult ChinhSuaTinTuc(string id, string tieude, string noidung, string ngaydang, string tacgia, HttpPostedFileBase hinhdaidien)
        {
            try
            {

                // Xử lý hình ảnh nếu có

                if (hinhdaidien != null && hinhdaidien.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(hinhdaidien.FileName);
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/images"), fileName);
                    hinhdaidien.SaveAs(path);
                    // Tạo đối tượng DataModel
                    DataModel db = new DataModel();
                    // Thực hiện cập nhật bệnh viện
                    db.get("EXEC SuaTinTuc N'" + tieude + "', N'" + noidung + "', '" + ngaydang + "', N'" + tacgia + "','"+ hinhdaidien.FileName + "' ," + id + ";");
                }
            }
            catch (Exception) { }
            return RedirectToAction("DanhSachTinTuc", "News", new { area = "Admin" });

        }
    }
}