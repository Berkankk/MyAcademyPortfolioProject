using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous] //herkes bu sayfaya erişebilmeli
    public class LoginController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities(); 

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmins admin)
        {
            var value = db.TblAdmins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password); //parametreden gelen değişkeni value değerine atadık
            if(value != null)
            {
                FormsAuthentication.SetAuthCookie(value.UserName, false);
                Session["userName"] = value.UserName; //süre boyunca hafızada tutuyor 
                return RedirectToAction("Index" , "About"); // nulldan farklı olursa aboutun indexine atıyor bizi  
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View(); // burada geri dönecek bizi başka bir yere atmayacak
                //cookie tarafına atama yaptık burada
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default"); //çıkış yaptıktan sonra defaultun indexine dön
        }
    }
} 