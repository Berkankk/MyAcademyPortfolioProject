using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var value = db.TblSocialMedias.ToList();
            return View(value);
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var sil = db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var sosyal = db.TblSocialMedias.Find(id);
            return View(sosyal);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedias socialMedias)
        {
            var sosyal = db.TblSocialMedias.Find(socialMedias.SocialMediaId); // sosyal değişkenine gelen idden değerleri bul ve koy
            sosyal.SocialMediaName = socialMedias.SocialMediaName;
            sosyal.Url = socialMedias.Url;
            sosyal.Icon = socialMedias.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedias socialMedias)
        {
            db.TblSocialMedias.Add(socialMedias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}