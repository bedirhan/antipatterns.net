using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntiPatterns.Utility
{
    public class Authenticator
    {
        public static bool Authenticate(string username, string password)
        {
            return false;
        }

        public static bool CheckCaptcha(string captcha)
        {
            return true;
        }
    }
}