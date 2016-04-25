using AntiPatterns.Models;
using AntiPatterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AntiPatterns.Controllers
{
    public class PardonTheMalintentController : Controller
    {
        AccountRepository accountRepository;
        public PardonTheMalintentController()
        {
            accountRepository = new AccountRepository();
        }
        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);
            if (ctx.HttpContext.Session["user"] == null)
            {
                ctx.HttpContext.Session["user"] = new User() { ID = 1,
                                                                Username = "burgun",
                                                                FullName = "Bedirhan Urgun"
                };
            }
        }

        public ActionResult Index()
        {
            User user = (User)Session["user"];
            return View(accountRepository.GetAccounts(user.ID));
        }
        public ActionResult Detail(int id)
        {
            return View(accountRepository.GetAccount(id));
        }
    }
}