using AntiPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AntiPatterns.Controllers
{
    public class IncompleteMediationController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);
            if (ctx.HttpContext.Session["user"] == null)
            {
                ctx.HttpContext.Session["user"] = new User()
                {
                    ID = 1,
                    Username = "burgun",
                    FullName = "Bedirhan Urgun",
                    IsAdmin = false,
                    Email = "bedirhan.urgun@gmail.com"
                };
            }
        }
        public ActionResult Index()
        {
            User user = (User)Session["user"];
            if (!user.IsAdmin)
            {
                ViewBag.Error = "Only Administrators can create new offers";
            }
            return View();
        }
        public ActionResult Add(Offer offer)
        {
            ViewBag.Result = "A new offer is created";
            return View("Index");
        }
    }
}