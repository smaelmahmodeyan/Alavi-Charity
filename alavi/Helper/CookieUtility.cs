using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace alavi.Helper
{
    public static class CookieUtility
    {
        private static readonly IEncryptString Encrypter = new ConfigurationBasedStringEncrypter();



        public static string GetUserName(){
            var cookie = HttpContext.Current.Request.Cookies["alaviUserName"];
            if (cookie != null)
                return Encrypter.Decrypt(cookie.Value);
            else
                return "";
        }


        /// <summary>
        /// متدی برای دریافت کوکی
        /// در صورت پیدا نکردن کوکی مقدار خالی برمی گرداند
        /// </summary>
        /// <param name="cookieName">نام کوکی</param>
        /// <returns></returns>
        public static string GetCookies(string cookieName)
        {
            var cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
                return Encrypter.Decrypt(cookie.ToString());
            else
                return "";
        }





        /// <summary>
        /// متدی برای افزودن کوکی
        /// در صورت وجود کوکی مقدار آن را جایگزین می نماید
        /// </summary>
        /// <param name="name">نام کوکی</param>
        /// <param name="value">مقدار کوکی</param>
        public static void AddCookies(string name, string value)
        {
            var p = HttpContext.Current.Request.Cookies[name];
            if (p != null)
            {

                p.Value = Encrypter.Encrypt(value);
                HttpContext.Current.Response.Cookies.Add(p);
            }
            else
            {
                HttpCookie Cookie = new HttpCookie(name);
                Cookie.HttpOnly = true;
                Cookie.Value = Encrypter.Encrypt(value);
                HttpContext.Current.Response.Cookies.Add(Cookie);
            }


        }

        /// <summary>
        /// متدی برای پاک کردن کوکی
        /// </summary>
        /// <param name="cookieName">نام کوکی</param>
        public static void ClearCookie(string cookieName)
        {
            var p = HttpContext.Current.Request.Cookies[cookieName];

            if (p != null)
            {
                p.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(p);
            }
        }
    }
}
