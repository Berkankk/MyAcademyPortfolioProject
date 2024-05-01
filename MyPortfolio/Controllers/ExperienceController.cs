using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var value = db.TblExperiences.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddExperience() //sadece sayfayı görüntüleriz
        {
            return View();
        }
        [HttpPost] // oluşturacağımız butona tıkladığımız zaman post metodu çalışacak ve kaydedecek sonunda ise bir önceki yani index sayfasına dönecek
        public ActionResult AddExperience(TblExperiences experiences) 
        {
            db.TblExperiences.Add(experiences);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            var sil = db.TblExperiences.Find(id); //İd den gelen değerle birlikte TblExperiences tablosundan gelen değeri buldu ve experience değişkenine atadı
            db.TblExperiences.Remove(sil);  // remove siler
            db.SaveChanges(); //kaydettik ve indexe geri gidiyouz
            return RedirectToAction("Index");

        }

        [HttpGet]

        public ActionResult UpdateExperience(int id)
        {
            var value = db.TblExperiences.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateExperience(TblExperiences experience)
        {
            var value = db.TblExperiences.Find(experience.ExperienceId);
            value.StartYear = experience.StartYear;
            value.EndYear = experience.EndYear;
            value.Title = experience.Title;
            value.Description = experience.Description;
            value.Company = experience.Company;
            value.Location = experience.Location;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}