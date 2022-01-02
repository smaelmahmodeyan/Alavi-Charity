using alavi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alavi.ViewModel;
using System.Data.Entity;

namespace alavi.Controllers
{
    public class HomeController : BaseController
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<alaviDbContext, Configuration>()); 
        public ActionResult Index()
        {
            using (var db = new alaviDbContext())
            {
                HomeViweModel home = new HomeViweModel();

                home.News = db.News.OrderByDescending(rec => rec.Date).Take(8).ToList();
                home.Childern = db.Childes.OrderByDescending(rec => rec.Id).Take(8).ToList();

                return View(home);
            }

        }

        public ActionResult Post(int id)
        {
            using (var db = new alaviDbContext())
            {


                var model = db.News.SingleOrDefault(rec => rec.Id == id);

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Contact()
        {
            var model = new Contact();
            return View(model);
        }
        [HttpPost]
        public ActionResult Contact(Contact cantact)
        {

            using (var db = new alaviDbContext())
            {

                db.Contacts.Add(cantact);
                db.SaveChanges();
                TempData["cantact"] = "پیام با موفقیت ارسال شد";
                return RedirectToAction("Contact");
            }

        }
        public ActionResult News()
        {
            using (var db = new alaviDbContext())
            {
                var model = db.News.OrderBy(rec => rec.Id).Take(20);
                return View(model);
            }


        }

        public JsonResult MoreNews(int skip, int take)
        {

            using (var db = new alaviDbContext())
            {
                var model = db.News.OrderBy(rec => rec.Id).Skip(skip * take).Take(take);

                return Json(model, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult Sponsor()
        {
            using (var db = new alaviDbContext())
            {
                var model = db.Sponsors.OrderBy(rec => rec.Id).Take(20);
                return View(model);
            }


        }
        public JsonResult MoreSponsor(int skip, int take)
        {
            using (var db = new alaviDbContext())
            {
                var model = db.Sponsors.OrderBy(rec => rec.Id).Skip(skip * take).Take(take);

                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetSponsor()
        {

            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Activities()
        {
            return View();
        }

        public ActionResult HelpUs()
        {

            return View();
        }
    }
}