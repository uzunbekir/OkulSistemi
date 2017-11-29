using MVCCodefirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCCodefirst.Controllers
{
    public class AdminEgitmenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: AdminEgitmen
        public ActionResult Index()
        {
            return View(db.Egitmenler.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //post işlemi için
        public ActionResult Create([Bind(Include = "EgitmenID,AdSoyad,DogumTarihi")]Egitmen egitmen)
        {
            if (ModelState.IsValid)
            {
                db.Egitmenler.Add(egitmen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(egitmen);
        }
        //get işlemi için 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Egitmen egitmen = db.Egitmenler.Find(id);
            if (egitmen == null)
            {
                return HttpNotFound();
            }
            return View(egitmen);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //post işlemi için
        public ActionResult Edit([Bind(Include = "EgitmenID,AdSoyad,DogumTarihi")]Egitmen egitmen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(egitmen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(egitmen);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Egitmen egitmen = db.Egitmenler.Find(id);
            if (egitmen == null)
            {
                return HttpNotFound();
            }
            return View(egitmen);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Egitmen egitmen = db.Egitmenler.Find(id);
            if (egitmen == null)
            {
                return HttpNotFound();
            }
            return View(egitmen);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //post işlemi için
        public ActionResult DeleteConfirmed(int id)
        {

            Egitmen egitmen = db.Egitmenler.Find(id);
            db.Egitmenler.Remove(egitmen);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}