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
            if(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return View("Index");
            }

            if(Authenticator.CheckCaptcha(captcha) && Authenticator.Authenticate(username, password))
            {
                Session["failedtries"] = 0;
                return View("Success");
            }
            else
            {
                // check a brute-force attack
                int failedtries = 0;
                if (Session["failedtries"] != null)
                {
                    failedtries = (int)Session["failedtries"];
                }

                if (failedtries >= 3)
                {
                    ViewBag.ShowCaptcha = true;
                    ViewBag.Result = "Too many failed login attempts, please enter CAPTCHA!";
                    return View("Index");
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