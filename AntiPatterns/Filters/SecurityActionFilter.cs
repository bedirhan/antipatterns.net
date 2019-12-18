using System;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Configuration;

namespace AntiPatterns.ActionFilters
{
    public class SecurityActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string mySecurityFilterRegex = ConfigurationManager.AppSettings["SecurityFilterRegex"];

            if (!String.IsNullOrEmpty(mySecurityFilterRegex))
            {
                foreach (string parameterName in filterContext.HttpContext.Request.Unvalidated.QueryString)
                {
                    string parameterValue = filterContext.HttpContext.Request.Unvalidated.QueryString[parameterName];

                    if (Regex.IsMatch(parameterValue, mySecurityFilterRegex))
                    {
                        filterContext.Result = new RedirectResult("/Blacklisting/Error");
                        return;
                    }
                }

                foreach (string parameterName in filterContext.HttpContext.Request.Unvalidated.Form)
                {
                    string parameterValue = filterContext.HttpContext.Request.Unvalidated.Form[parameterName];

                    if (Regex.IsMatch(parameterValue, mySecurityFilterRegex))
                    {
                        filterContext.Result = new RedirectResult("/Blacklisting/Error");
                        return;
                    }
                }

            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

    }
}