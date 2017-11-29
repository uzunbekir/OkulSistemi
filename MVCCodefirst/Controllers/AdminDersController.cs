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
    public class AdminDersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: AdminDers
        public ActionResult Index()
        {
            return View(db.Dersler.ToList());
        }
        //Get işlemi için
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //post işlemi için
        public ActionResult Create([Bind(Include ="DersID,DersAdi,Aciklama")]Ders ders)
        {
            if (ModelState.IsValid)
            {
                db.Dersler.Add(ders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ders);
        }
        //get işlemi için 
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = db.Dersler.Find(id);
            if (ders==null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //post işlemi için
        public ActionResult Edit([Bind(Include= "DersID,DersAdi,Aciklama")]Ders ders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ders);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = db.Dersler.Find(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = db.Dersler.Find(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //post işlemi için
        public ActionResult DeleteConfirmed(int id)
        {
           
                Ders ders = db.Dersler.Find(id);
                db.Dersler.Remove(ders);
                db.SaveChanges();
                return RedirectToAction("Index");
          
        }
    }
}