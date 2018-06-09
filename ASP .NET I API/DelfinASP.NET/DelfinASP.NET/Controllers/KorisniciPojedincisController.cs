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
    public class KorisniciPojedincisController : Controller
    {
        private DelfinContext db = new DelfinContext();

        string apiUrl = "http://delfinapi20180609105232.azurewebsites.net/";
        public async Task<ActionResult> Index1()
        {

            List<KorisniciPojedinci> korisnici = new List<KorisniciPojedinci>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/KorisniciPojedincis/");
                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    korisnici = JsonConvert.DeserializeObject<List<KorisniciPojedinci>>(response);

                }
            }


            return View(korisnici);
        }
        // GET: KorisniciPojedincis
        public ActionResult Index()
        {
            return View(db.KorisniciPojednici.ToList());
        }

        // GET: KorisniciPojedincis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KorisniciPojedinci korisniciPojedinci = db.KorisniciPojednici.Find(id);
            if (korisniciPojedinci == null)
            {
                return HttpNotFound();
            }
            return View(korisniciPojedinci);
        }

        // GET: KorisniciPojedincis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KorisniciPojedincis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KorisniciPojedinciID,Ime,Prezime,JMBG,DatumRodjenja,KorisnickoIme,Lozinka")] KorisniciPojedinci korisniciPojedinci)
        {
            if (ModelState.IsValid)
            {
                db.KorisniciPojednici.Add(korisniciPojedinci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(korisniciPojedinci);
        }

        // GET: KorisniciPojedincis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KorisniciPojedinci korisniciPojedinci = db.KorisniciPojednici.Find(id);
            if (korisniciPojedinci == null)
            {
                return HttpNotFound();
            }
            return View(korisniciPojedinci);
        }

        // POST: KorisniciPojedincis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KorisniciPojedinciID,Ime,Prezime,JMBG,DatumRodjenja,KorisnickoIme,Lozinka")] KorisniciPojedinci korisniciPojedinci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisniciPojedinci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisniciPojedinci);
        }

        // GET: KorisniciPojedincis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KorisniciPojedinci korisniciPojedinci = db.KorisniciPojednici.Find(id);
            if (korisniciPojedinci == null)
            {
                return HttpNotFound();
            }
            return View(korisniciPojedinci);
        }

        // POST: KorisniciPojedincis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KorisniciPojedinci korisniciPojedinci = db.KorisniciPojednici.Find(id);
            db.KorisniciPojednici.Remove(korisniciPojedinci);
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
