using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous] //herkes buna erişebilmeli
    public class DefaultController : Controller
    {
        // GET: Default

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultFeaturePartial()
        {
            var values = db.TblFeatures.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultAboutPartial() 
        {
            var values = db.TblAbouts.ToList();
            return PartialView(values);
        }

        [HttpGet]

        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        
        [HttpPost]
        public ActionResult SendMessage(TblMessages messages)
        {
            db.TblMessages.Add(messages);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }

        public PartialViewResult DefaultServicePartial()
        {
            var values = db.TblServices.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultSkillPartial()
        {
            var value = db.TblSkills.ToList();
            return PartialView(value);
        }
        public  PartialViewResult DefaultProjectPartial()
        {
            //var categories = db.TblCategories.ToList();
            //ViewBag.Categories = categories;

            var value = db.TblProjects.ToList();
            return PartialView(value);
        }
        public PartialViewResult DefaultExperiencePartial()
        {
            var value = db.TblExperiences.ToList();
            return PartialView(value);
        }
        public PartialViewResult DefaultTestimonialPartial()
        {
            var value = db.TblTestimonials.Where(x=>x.Status == true).ToList();
            return PartialView(value);
        }
        public PartialViewResult DefaultTeamPartial()
        {
            var value = db.TblTeams.ToList();
            return PartialView(value);
        }
    }
}