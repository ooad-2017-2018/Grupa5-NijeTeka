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
    public class RecepcionarsController : Controller
    {
        private DelfinContext db = new DelfinContext();

        string apiUrl = "http://delfinapi20180609105232.azurewebsites.net/";
        public async Task<ActionResult> Index1()
        {

            List<Recepcionar> recepcionari = new List<Recepcionar>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Recepcionars/");
                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    recepcionari = JsonConvert.DeserializeObject<List<Recepcionar>>(response);

                }
            }


            return View(recepcionari);
        }

        // GET: Recepcionars
        public ActionResult Index()
        {
            return View(db.Recepcionari.ToList());
        }

        // GET: Recepcionars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepcionar recepcionar = db.Recepcionari.Find(id);
            if (recepcionar == null)
            {
                return HttpNotFound();
            }
            return View(recepcionar);
        }

        // GET: Recepcionars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recepcionars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecepcionarID,Ime,Prezime,DatumRodjenja,Plata,KorisnickoIme,Lozinka")] Recepcionar recepcionar)
        {
            if (ModelState.IsValid)
            {
                db.Recepcionari.Add(recepcionar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recepcionar);
        }

        // GET: Recepcionars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepcionar recepcionar = db.Recepcionari.Find(id);
            if (recepcionar == null)
            {
                return HttpNotFound();
            }
            return View(recepcionar);
        }

        // POST: Recepcionars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecepcionarID,Ime,Prezime,DatumRodjenja,Plata,KorisnickoIme,Lozinka")] Recepcionar recepcionar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recepcionar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recepcionar);
        }

        // GET: Recepcionars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepcionar recepcionar = db.Recepcionari.Find(id);
            if (recepcionar == null)
            {
                return HttpNotFound();
            }
            return View(recepcionar);
        }

        // POST: Recepcionars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recepcionar recepcionar = db.Recepcionari.Find(id);
            db.Recepcionari.Remove(recepcionar);
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
