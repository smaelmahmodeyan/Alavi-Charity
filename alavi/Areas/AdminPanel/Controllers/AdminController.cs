using alavi.Areas.AdminPanel.Filter;
using alavi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility.datatable;

namespace alavi.Areas.AdminPanel.Controllers
{
    [Adminfilter]
    public class AdminController : Controller
    {
        //
        // GET: /AdminPanel/Admin/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// خروج از سیستم
        /// </summary>
        /// <returns></returns>
        public ActionResult SingOut()
        {
            alavi.Helper.CookieUtility.ClearCookie("alaviUserName");
            return RedirectToAction("Index", "Login");
        }



        public ActionResult ListUser()
        {
            return View();
        }

        public ActionResult News()
        {

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNews(News news)
        {
            news.Date = DateTime.Now;
            using (var db = new alaviDbContext())
            {
                db.News.Add(news);
                db.SaveChanges();
                TempData["News"] = "خبر با موفقیت درج شد";
                return RedirectToAction("News");
            }
        }
        [HttpGet]
        public ActionResult AddNews()
        {

            return View();
        }

        public ActionResult Image()
        {

            return View();
        }

      

        [HttpPost]
        public JsonResult Image(string ImageName,string filename)
        {

            using (var db = new alaviDbContext())
            {
                Image img = new Models.Image();
                img.Name = ImageName;
                img.Url = System.IO.Path.Combine(Server.MapPath("/Image/"), filename);
                db.Images.Add(img);
                db.SaveChanges();
                TempData["Image"] = "عکس با موفقیت آپلود شود";
                return Json("Ok");
            }

        }

        public ActionResult Sponsor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sponsor(Sponsor sponsor)
        {
            using (var db = new alaviDbContext())
            {
                db.Sponsors.Add(sponsor);
                db.SaveChanges();
                TempData["Sponsor"] = "کودک با موفقیت افزوده شد";
                return RedirectToAction("sponsor");
            }

        }
        public ActionResult AdminUser()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdminUser(AdminUser user)
        {
            using (var db = new alaviDbContext())
            {
                db.adminUsers.Add(user);
                db.SaveChanges();
                TempData["AdminUser"] = "کاربر با موفقیت افزوده شد";
                return RedirectToAction("adminUser");
            }

        }

        public ActionResult Contact()
        {
            return View();
        }

        public JsonResult ReadContact(int id)
        {
            using (var db = new alaviDbContext())
            {

                var model = db.Contacts.SingleOrDefault(rec => rec.Id == id);
                return Json(model, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult Sandogh()
        {
            return View();
        }

        public JsonResult ReadSandogh(int id)
        {

            using (var db = new alaviDbContext())
            {
                var model = db.Sandoghs.SingleOrDefault(rec => rec.Id == id);
                return Json(model, JsonRequestBehavior.AllowGet);

            }


        }

        public JsonResult postFile()
        {


            if (Request.Files.AllKeys.Any())
            {
                foreach (string file in Request.Files)
                {
                    var httpPostedFile = Request.Files[file];
                    if (httpPostedFile.ContentLength == 0)
                        continue;
                    string fileSavePath = System.IO.Path.Combine(Server.MapPath("/Image/"), httpPostedFile.FileName);
                    httpPostedFile.SaveAs(fileSavePath);

                }
                return Json("ok");
            }
            else
            {
                return Json("error");
            }

        }

        public JsonResult postNewsFile()
        {


            if (Request.Files.AllKeys.Any())
            {
                foreach (string file in Request.Files)
                {
                    var httpPostedFile = Request.Files[file];
                    if (httpPostedFile.ContentLength == 0)
                        continue;
                    string fileSavePath = System.IO.Path.Combine(Server.MapPath("/Image/News"), httpPostedFile.FileName);
                    httpPostedFile.SaveAs(fileSavePath);

                }
                return Json("ok");
            }
            else
            {
                return Json("error");
            }

        }


    }
}