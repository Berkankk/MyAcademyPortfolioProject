using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TeamController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var value = db.TblTeams.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddTeam()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult AddTeam(TblTeams teams)
        {
            db.TblTeams.Add(teams);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTeam(int id)
        {
            var sil = db.TblTeams.Find(id);
            db.TblTeams.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult UpdateTeam(int id) // önce id ye bağlı değerleri getirmesi için (formu açınca o idye bağlı değerlerin gelmesi) httpget metodu 
        {
            var team = db.TblTeams.Find(id);
            return View(team);
        }


        [HttpPost]
        public ActionResult UpdateTeam(TblTeams teams)  
        {
            var value = db.TblTeams.Find(teams.TeamId); 
            value.ImageUrl = teams.ImageUrl;  // parametrelerime atamalarımı yaptım
            value.NameSurname = teams.NameSurname;
            value.Title = teams.Title;
            value.Description = teams.Description;
            value.TwitterUrl = teams.TwitterUrl;
            value.FacebookUrl = teams.FacebookUrl;
            value.LinkedinUrl = teams.LinkedinUrl;
            value.InstagramUrl = teams.InstagramUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}