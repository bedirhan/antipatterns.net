using AntiPatterns.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace AntiPatterns.Controllers
{
    public class WideningWhitelistsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult Search(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                // AR-342 Requirement: being able to search 
                // multiple words with & and empty characters

                // AR-572 Fast Track: being able to search 
                // similar words with # character
                if (Regex.IsMatch(search, @"^[\w]+$"))
                {
                    ViewBag.Search = search;
                    ViewBag.Result = IpsumGenerator.GenerateIpsum(3);
                }
                else
                {
                    ViewBag.Search = "-";
                    ViewBag.Result = "Bad Input!";
                }
            }
            return View();
        }

        public string Trend()
        {
            return String.Empty;
        }
    }
}