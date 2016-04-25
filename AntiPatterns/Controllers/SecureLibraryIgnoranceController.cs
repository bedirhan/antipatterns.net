using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AntiPatterns.Controllers
{
    public class SecureLibraryIgnoranceController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}