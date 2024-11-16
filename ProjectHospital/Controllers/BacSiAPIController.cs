using ProjectHospital.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHospital.Controllers
{
    public class BacSiAPIController : Controller
    {
        // GET: BacSiAPI
        public ActionResult Index()
        {
            DataModel db= new DataModel();
            ArrayList a = db.get("exec LayTTbacSi");
            return Json(a,JsonRequestBehavior.AllowGet);

        }
    }
}