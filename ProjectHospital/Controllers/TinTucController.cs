using ProjectHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Controllers
{
    public class TinTucController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            DataModel db = new DataModel();
            ViewBag.listTT = db.get("Select * from TinTuc");
            return View();
        }
    }
}