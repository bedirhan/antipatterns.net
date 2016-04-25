using AntiPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AntiPatterns.Controllers
{
    public class ConfirmationBiasController : Controller
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
                    Bio = "A software security enthusiast, developer and that's all.",
                    IsAdmin = false,
                    Email = "bedirhan.urgun@gmail.com"
                };
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            Session["user"] = user;
            return View("Index");
        }
    }
}