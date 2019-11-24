using EmployeeMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmployeeMVC.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        EmployeeDBEntities db=new EmployeeDBEntities();
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            var user = db.Kullanici.FirstOrDefault(x => x.Ad == kullanici.Ad &&x.Sifre==kullanici.Sifre);
            if (user!=null)
            {
                FormsAuthentication.SetAuthCookie(user.Ad,false);
                return RedirectToAction("Index","Departmant");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanıcı adı veya şifre";
                return View();
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}