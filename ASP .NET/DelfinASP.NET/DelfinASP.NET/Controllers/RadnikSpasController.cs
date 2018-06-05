using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DelfinASP.NET.Models;

namespace DelfinASP.NET.Controllers
{
    public class RadnikSpasController : Controller
    {
        private DelfinContext db = new DelfinContext();

        // GET: RadnikSpas
        public ActionResult Index()
        {
            return View(db.Radnicispa.ToList());
        }

        // GET: RadnikSpas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadnikSpa radnikSpa = db.Radnicispa.Find(id);
            if (radnikSpa == null)
            {
                return HttpNotFound();
            }
            return View(radnikSpa);
        }

        // GET: RadnikSpas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RadnikSpas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RadnikSpaID,Ime,Prezime,DatumRodjenja,Plata,KorisnickoIme,Lozinka")] RadnikSpa radnikSpa)
        {
            if (ModelState.IsValid)
            {
                db.Radnicispa.Add(radnikSpa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(radnikSpa);
        }

        // GET: RadnikSpas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadnikSpa radnikSpa = db.Radnicispa.Find(id);
            if (radnikSpa == null)
            {
                return HttpNotFound();
            }
            return View(radnikSpa);
        }

        // POST: RadnikSpas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RadnikSpaID,Ime,Prezime,DatumRodjenja,Plata,KorisnickoIme,Lozinka")] RadnikSpa radnikSpa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radnikSpa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(radnikSpa);
        }

        // GET: RadnikSpas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadnikSpa radnikSpa = db.Radnicispa.Find(id);
            if (radnikSpa == null)
            {
                return HttpNotFound();
            }
            return View(radnikSpa);
        }

        // POST: RadnikSpas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RadnikSpa radnikSpa = db.Radnicispa.Find(id);
            db.Radnicispa.Remove(radnikSpa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
