using AntiPatterns.Models;
using AntiPatterns.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AntiPatterns.Controllers
{
    public class CopyPasteInsecureCodeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult Preview()
        {
            List<Offer> offers = new List<Offer>();
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    ViewBag.FileName = file.FileName;
                    offers = OfferParser.GetOffers(file.InputStream);
                }
            }
            else
            {
                ViewBag.FileName = "No file is uploaded";
            }

            return View(offers);
        }
    }
}