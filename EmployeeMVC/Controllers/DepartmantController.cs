using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeMVC.DAL;
using EmployeeMVC.Models;

namespace EmployeeMVC.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class DepartmantController : Controller
    {
        EmployeeDBEntities db=new EmployeeDBEntities();
     
        [Authorize]
        public ActionResult Index()
        {
            var model = db.Departman.ToList();
            return View(model);
        }
        public ActionResult Kaydet()
        {           
            return View("DepartmantForm",new Departman());
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Kaydet(Departman depertman)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmantForm");
            }
            MesajFormModel model=new MesajFormModel();
            if (depertman.Id==0)
            {
                db.Departman.Add(depertman);
                model.Mesaj = depertman.Ad + " başarılıyla eklendi.";
            }
            if (depertman.Id==0)
            {
                db.Departman.Add(depertman);
                db.SaveChanges();
            }
            else
            {
                var gelecekdep = db.Departman.Find(depertman.Id);
                if (gelecekdep==null)
                {
                    return HttpNotFound();
                }

                gelecekdep.Ad = depertman.Ad;
                model.Mesaj= depertman.Ad + " başarılıyla güncellendi.";
            }

            db.SaveChanges();
            model.Status = true;
            model.LinkText = "Departman Listesi";
            model.Url = "/Departmant";         
            return View("_Mesaj",model);
        }
        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model==null)
            {
                return HttpNotFound();
            }
            return View("DepartmantForm",model);
        }
        public ActionResult Sil(int id)
        {
            var sildep = db.Departman.Find(id);
            if (sildep==null)
            {
                return HttpNotFound();
            }
            db.Departman.Remove(sildep);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}