using alavi.Helper;
using alavi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace alavi.Areas.AdminPanel.Controllers
{
    public class LoginController : Controller
    {
        private static readonly IEncryptString Encrypter = new ConfigurationBasedStringEncrypter();
        //
        // GET: /AdminPanel/Login/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(AdminUser user)
        {

            using (var db = new alaviDbContext())
            {

                var password=Encrypter.Encrypt(user.Password);
          var count= db.adminUsers.Count(rec => rec.UserName == user.UserName && rec.Password ==password );

          if (count == 1)
          {

              alavi.Helper.CookieUtility.AddCookies("alaviUserName", user.UserName);
            
              //alavi.Helper.CookieUtility.AddCookies("AlaviImage", user.Image);
              return RedirectToAction("Index","admin");
          }
          else {
              TempData["Login"] = "نام کاربری یا کلمه عبور صحیح نمی باشد";
              return RedirectToAction("Index");
          }
            }


        }
	}
}