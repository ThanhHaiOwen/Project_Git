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
                    var result = db.get("EXEC ThemBenhVien N'" + tenbenhvien + "', N'" + diachi + "', '" + sdt + "', N'" + chuyenve + "', '" + anhbenhvien + "';");

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
        public ActionResult ChinhSuaBenhVien()
        {
            return View();
        }
        public ActionResult ChiTietBenhVien(int id)
        {
            DataModel db = new DataModel();
            ViewBag.listBV = db.get("EXEC ChiTietBenhVien " + id + ";");
            return View();
        }

    }
}