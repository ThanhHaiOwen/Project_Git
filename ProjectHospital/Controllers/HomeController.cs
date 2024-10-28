using ProjectHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
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

	}
}