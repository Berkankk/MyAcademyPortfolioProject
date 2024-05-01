using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblContacts.ToList();
            return View(values);
        }

        [HttpGet] // sadece sayfayı görüntülemek için kullanılır
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost] // içerisinde form oluşturdğumuz ve butona tıkladığımız zaman post metodu çalışır.
        public ActionResult AddContact(TblContacts contact)
        {
            db.TblContacts.Add(contact); // db nesnesine tblabouts tablosundan abouts parametresii metotla verdik
            db.SaveChanges(); // değişiklikleri kaydettik bunu yapmazsak ekleme işlemi gerçekleşmez
            return RedirectToAction("Index"); // index sayfasına geri gönder
        }
        public ActionResult DeleteContact(int id)
        {
            var contact = db.TblContacts.Find(id); // id den gelen değeri bul ve tblabouta ata
            db.TblContacts.Remove(contact); //iden gelen değeri bulur ve siler
            db.SaveChanges();   //kaydet
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contact = db.TblContacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContacts contact)
        {
            var value = db.TblContacts.Find(contact.ContactId); // value değişkenine gelen değerleri ata
            value.NameSurname = contact.NameSurname;
            value.Address = contact.Address;
            value.Phone = contact.Phone;
            value.Email = contact.Email;
            db.SaveChanges();
            return RedirectToAction("Index");  // güncelleme işleminden sonra index sayfasına geri dön
        }
    }
}