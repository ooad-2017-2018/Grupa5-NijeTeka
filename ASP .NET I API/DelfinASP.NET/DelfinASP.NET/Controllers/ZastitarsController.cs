﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DelfinASP.NET.Models;
using Newtonsoft.Json;

namespace DelfinASP.NET.Controllers
{
    public class ZastitarsController : Controller
    {
        private DelfinContext db = new DelfinContext();

        string apiUrl = "http://delfinapi20180609105232.azurewebsites.net/";
        public async Task<ActionResult> Index1()
        {

            List<Zastitar> zastitari = new List<Zastitar>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Zastitars/");
                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    zastitari = JsonConvert.DeserializeObject<List<Zastitar>>(response);

                }
            }


            return View(zastitari);
        }

        // GET: Zastitars
        public ActionResult Index()
        {
            return View(db.Zastitari.ToList());
        }

        // GET: Zastitars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zastitar zastitar = db.Zastitari.Find(id);
            if (zastitar == null)
            {
                return HttpNotFound();
            }
            return View(zastitar);
        }

        // GET: Zastitars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zastitars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZastitarID,Ime,Prezime,DatumRodjenja,Plata,KorisnickoIme,Lozinka")] Zastitar zastitar)
        {
            if (ModelState.IsValid)
            {
                db.Zastitari.Add(zastitar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zastitar);
        }

        // GET: Zastitars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zastitar zastitar = db.Zastitari.Find(id);
            if (zastitar == null)
            {
                return HttpNotFound();
            }
            return View(zastitar);
        }

        // POST: Zastitars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZastitarID,Ime,Prezime,DatumRodjenja,Plata,KorisnickoIme,Lozinka")] Zastitar zastitar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zastitar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zastitar);
        }

        // GET: Zastitars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zastitar zastitar = db.Zastitari.Find(id);
            if (zastitar == null)
            {
                return HttpNotFound();
            }
            return View(zastitar);
        }

        // POST: Zastitars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zastitar zastitar = db.Zastitari.Find(id);
            db.Zastitari.Remove(zastitar);
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
