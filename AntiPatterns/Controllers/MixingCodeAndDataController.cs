using AntiPatterns.Models;
using AntiPatterns.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AntiPatterns.Controllers
{
    public class MixingCodeAndDataController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search(string title)
        {
            if (String.IsNullOrEmpty(title))
            {
                return View("Index");
            }

            string appdata = Server.MapPath("~/App_Data");
            string xmlPath = Path.Combine(appdata, "offers.xml");

            List<Offer> offers = OfferParser.QueryOffer(title, xmlPath);

            return View(offers);
        }
    }
}