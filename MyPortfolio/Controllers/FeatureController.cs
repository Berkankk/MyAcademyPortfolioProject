using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblFeatures.ToList();
            return View(values);
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = db.TblFeatures.Find(id);
            db.TblFeatures.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(TblFeatures features)
        {
            db.TblFeatures.Add(features);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.TblFeatures.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateFeature(TblFeatures features) // gelen değerleri güncelleme işlemi yapması için gerekli metodu yazdık
        {
            var value = db.TblFeatures.Find(features.FeatureId);
            value.NameSurname = features.NameSurname;
            value.Title = features.Title;
            value.ImageUrl= features.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}