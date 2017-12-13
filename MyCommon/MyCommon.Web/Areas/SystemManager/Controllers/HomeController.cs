using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCommon.Web.Areas.SystemManager.Controllers
{
    public class HomeController : Controller
    {
        // GET: SystemManager/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}