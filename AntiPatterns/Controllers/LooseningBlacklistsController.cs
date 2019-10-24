using AntiPatterns.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace AntiPatterns.Controllers
{
    public class LooseningBlacklistsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult Search(string search)
        {
            if(!String.IsNullOrEmpty(search))
            {
                // AR-139 Requirement: letting users to search with & character 
                // that is searching using multiple words
                if (Regex.IsMatch(search, @"[\'\<\(\&\;]"))
                {
                    ViewBag.Search = "-";
                    ViewBag.Result = "Bad Input!";
                }
                else
                {
                    ViewBag.Search = search;
                    ViewBag.Result = IpsumGenerator.GenerateIpsum(3);
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