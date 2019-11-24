using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeMVC.DAL;
using  System.Data.Entity;
using EmployeeMVC.Models;

namespace EmployeeMVC.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class PersonelController : Controller
    {
        EmployeeDBEntities db=new EmployeeDBEntities();

        // GET: Personel

        public ActionResult Index()
        {

            var liste = db.Personel.Include(p => p.Departman).ToList();
            return View(liste);
        }

        public ActionResult Kaydet()
        {
            var model = new PersonelFormModels()
            {
                departmanlar =db.Departman.ToList(),
                personel = new Personel()
            };

            return View("PersonelForm",model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model=new PersonelFormModels()
                {
                    departmanlar = db.Departman.ToList(),
                    personel = personel
                };
                return View("PersonelForm",model);
            }
            if (personel.Id==0)
            {
                db.Personel.Add(personel);
            }
            else
            {
                db.Entry(personel).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormModels()
            {
                departmanlar = db.Departman.ToList(),
                personel = db.Personel.Find(id)
        };
            return View("PersonelForm",model);
        }
        public ActionResult Sil(int id)
        {
            var silinecekpersonel = db.Personel.Find(id);
            if (silinecekpersonel==null)
            {
                HttpNotFound();
            }
            db.Personel.Remove(silinecekpersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelleriListele(int id)
        {
            var listele = db.Personel.Where(x => x.DepartmanId == id).ToList();
            return PartialView(listele);
        }

        public int? ToplamMaas()
        {
            return db.Personel.Sum(x => x.Maas);
        }
    }
}