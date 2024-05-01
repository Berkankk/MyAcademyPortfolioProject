using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProfileController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var value = db.TblAdmins.ToList();
            return View(value);
        }

        [AllowAnonymous] // bu, action metodların yetkilendirme gereksinimlerinden muaf tutuyor!!!!!!!
        
        public ActionResult UpdateProfile(int id)
        {
            var pro = db.TblAdmins.Find(id);
            return View(pro);
        }

        [HttpPost]
        public ActionResult UpdateProfile(TblAdmins admins)
        {
            var gnc = db.TblAdmins.Find(admins.AdminId);
            gnc.AdminId = admins.AdminId;
            gnc.UserName = admins.UserName;
            gnc.Password = admins.Password;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}