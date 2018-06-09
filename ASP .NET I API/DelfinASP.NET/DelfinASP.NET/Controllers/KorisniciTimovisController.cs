using System;
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
    public class KorisniciTimovisController : Controller
    {
        private DelfinContext db = new DelfinContext();

        string apiUrl = "http://delfinapi20180609105232.azurewebsites.net/";
        public async Task<ActionResult> Index1()
        {

            List<KorisniciTimovi> korisnici = new List<KorisniciTimovi>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/KorisniciTimovis/");
                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    korisnici = JsonConvert.DeserializeObject<List<KorisniciTimovi>>(response);

                }
            }


            return View(korisnici);
        }

        // GET: KorisniciTimovis
        public ActionResult Index()
        {
            return View(db.KorisniciTimovi.ToList());
        }

        // GET: KorisniciTimovis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KorisniciTimovi korisniciTimovi = db.KorisniciTimovi.Find(id);
            if (korisniciTimovi == null)
            {
                return HttpNotFound();
            }
            return View(korisniciTimovi);
        }

        // GET: KorisniciTimovis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KorisniciTimovis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KorisniciTimoviID,ImeTima,ImeTrenera,BrojClanova,DatumOsnivanja,KorisnickoIme,Lozinka")] KorisniciTimovi korisniciTimovi)
        {
            if (ModelState.IsValid)
            {
                db.KorisniciTimovi.Add(korisniciTimovi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(korisniciTimovi);
        }

        // GET: KorisniciTimovis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KorisniciTimovi korisniciTimovi = db.KorisniciTimovi.Find(id);
            if (korisniciTimovi == null)
            {
                return HttpNotFound();
            }
            return View(korisniciTimovi);
        }

        // POST: KorisniciTimovis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KorisniciTimoviID,ImeTima,ImeTrenera,BrojClanova,DatumOsnivanja,KorisnickoIme,Lozinka")] KorisniciTimovi korisniciTimovi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisniciTimovi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisniciTimovi);
        }

        // GET: KorisniciTimovis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KorisniciTimovi korisniciTimovi = db.KorisniciTimovi.Find(id);
            if (korisniciTimovi == null)
            {
                return HttpNotFound();
            }
            return View(korisniciTimovi);
        }

        // POST: KorisniciTimovis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KorisniciTimovi korisniciTimovi = db.KorisniciTimovi.Find(id);
            db.KorisniciTimovi.Remove(korisniciTimovi);
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
