using AntiPatterns.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AntiPatterns.Controllers
{
    public class LackOfWWWKnowledgeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string captcha)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return View("Index");
            }

            // check a brute-force attack
            int failedtries = 1;
            if (Session["failedtries"] != null)
            {
                failedtries = (int)Session["failedtries"];
            }
            if (failedtries >= 2)
            {
                if (Authenticator.CheckCaptcha(captcha))
                {
                    if (Authenticator.Authenticate(username, password))
                    {
                        Session["failedtries"] = 0;
                        return View("Success");
                    }
                    else
                    {
                        ViewBag.ShowCaptcha = true;
                        ViewBag.Result = "Username or password is wrong, please enter again!";
                    }
                }
                else
                {
                    ViewBag.ShowCaptcha = true;
                    ViewBag.Result = "Please enter correct CAPTCHA!";
                }
            }
            else
            {
                if (Authenticator.Authenticate(username, password))
                {
                    Session["failedtries"] = 0;
                    return View("Success");
                }
                else
                {
                    Session["failedtries"] = ++failedtries;
                    ViewBag.Result = "Username or password is wrong, please enter again!";
                }
            }

            return View("Index");
        }
    }
}