﻿using AntiPatterns.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AntiPatterns.Controllers
{
    public class BlacklistingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult Search(string search)
        {
            ViewBag.Search = search;
            ViewBag.Result = IpsumGenerator.GenerateIpsum(3);
            return View();
        }

        public string Trend()
        {
            return String.Empty;
        }
    }
}