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
    public class UpraviteljsController : Controller
    {
        private DelfinContext db = new DelfinContext();

        string apiUrl = "http://delfinapi20180609105232.azurewebsites.net/";
        public async Task<ActionResult> Index1()
        {

            List<Upravitelj> upravitelji = new List<Upravitelj>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Upraviteljs/");
                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    upravitelji = JsonConvert.DeserializeObject<List<Upravitelj>>(response);

                }
            }


            return View(upravitelji);
        }

        // GET: Upraviteljs
        public ActionResult Index()
        {
            return View(db.Upravitelj.ToList());
        }

        // GET: Upraviteljs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Upravitelj upravitelj = db.Upravitelj.Find(id);
            if (upravitelj == null)
            {
                return HttpNotFound();
            }
            return View(upravitelj);
        }

        // GET: Upraviteljs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Upraviteljs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "upraviteljID,Ime,Prezime,DatumRodjenja,Plata,KorisnickoIme,Lozinka")] Upravitelj upravitelj)
        {
            if (ModelState.IsValid)
            {
                db.Upravitelj.Add(upravitelj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(upravitelj);
        }

        // GET: Upraviteljs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Upravitelj upravitelj = db.Upravitelj.Find(id);
            if (upravitelj == null)
            {
                return HttpNotFound();
            }
            return View(upravitelj);
        }

        // POST: Upraviteljs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "upraviteljID,Ime,Prezime,DatumRodjenja,Plata,KorisnickoIme,Lozinka")] Upravitelj upravitelj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(upravitelj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(upravitelj);
        }

        // GET: Upraviteljs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Upravitelj upravitelj = db.Upravitelj.Find(id);
            if (upravitelj == null)
            {
                return HttpNotFound();
            }
            return View(upravitelj);
        }

        // POST: Upraviteljs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Upravitelj upravitelj = db.Upravitelj.Find(id);
            db.Upravitelj.Remove(upravitelj);
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
