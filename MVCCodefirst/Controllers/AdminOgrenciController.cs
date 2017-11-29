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
    public class AdminOgrenciController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: AdminOgrenci
        public ActionResult Index()
        {
            return View(db.Ogrenciler.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //post işlemi için
        public ActionResult Create([Bind(Include = "OgrenciID,AdSoyad,DogumTarihi,MezunMu,Ortalama")]Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Ogrenciler.Add(ogrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }
        //get işlemi için 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //post işlemi için
        public ActionResult Edit([Bind(Include = "OgrenciID,AdSoyad,DogumTarihi,MezunMu,Ortalama")]Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //post işlemi için
        public ActionResult DeleteConfirmed(int id)
        {

            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            db.Ogrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}