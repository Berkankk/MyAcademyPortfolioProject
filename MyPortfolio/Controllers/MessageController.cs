using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var value = db.TblMessages.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddMessage() // mesaj sayfasını görüntüleriz sadece
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(TblMessages messages)
        {
            db.TblMessages.Add(messages);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var mesaj = db.TblMessages.Find(id);
            return View(mesaj);
        }

        [HttpPost]
        public ActionResult UpdateMessage(TblMessages messages)
        {
            var value = db.TblMessages.Find(messages.MessageId);
            value.Name = messages.Name;
            value.Email = messages.Email;
            value.Subject = messages.Subject;
            value.MessageContent = messages.MessageContent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = db.TblMessages.Find(id);
            db.TblMessages.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}