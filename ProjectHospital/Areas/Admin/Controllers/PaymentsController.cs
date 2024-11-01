using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Areas.Admin.Controllers
{
    public class PaymentsController : Controller
    {
        // GET: Admin/Payments
        public ActionResult ThemPhuongThuc()
        {
            return View();
        }
    }
}