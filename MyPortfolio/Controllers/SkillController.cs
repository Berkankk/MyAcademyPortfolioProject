using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var value = db.TblSkills.ToList();
            return View(value);
        }

        [HttpGet]

        public ActionResult AddSkill()
        {
            return View(); // Skill sayfasını görüntüleriz sadece 
        }

        [HttpPost]
        public ActionResult AddSkill(TblSkills skills)
        {
            db.TblSkills.Add(skills);
            db.SaveChanges();
            return View();
        }

        public ActionResult DeleteSkill(int id)
        {
            var value=  db.TblSkills.Find(id);
            db.TblSkills.Remove(value); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var ytn = db.TblSkills.Find(id);
            return View(ytn);
        }
        [HttpPost]
        public ActionResult UpdateSkill(TblSkills skills)
        {
            var yettn = db.TblSkills.Find(skills.SkillId);
            yettn.SkillName = skills.SkillName;
            yettn.Value = skills.Value;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}