
namespace AntiPatterns.Utility
{
    public class Authenticator
    {
        public static bool Authenticate(string username, string password)
        {
            if(username == "bedirhan@sourceflake.com" && password == "11")
            {
                return true;
            }

            return false;
        }

        public static bool CheckCaptcha(string captcha)
        {
            if(captcha == "enertioc")
            {
                return true;
            }
            return false;
        }
    }
}