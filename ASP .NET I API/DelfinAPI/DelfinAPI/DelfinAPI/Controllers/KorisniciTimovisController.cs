using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DelfinAPI.Models;

namespace DelfinAPI.Controllers
{
    public class KorisniciTimovisController : ApiController
    {
        private DelfinModel db = new DelfinModel();

        // GET: api/KorisniciTimovis
        public IQueryable<KorisniciTimovi> GetKorisniciTimovi()
        {
            return db.KorisniciTimovi;
        }

        // GET: api/KorisniciTimovis/5
        [ResponseType(typeof(KorisniciTimovi))]
        public IHttpActionResult GetKorisniciTimovi(int id)
        {
            KorisniciTimovi korisniciTimovi = db.KorisniciTimovi.Find(id);
            if (korisniciTimovi == null)
            {
                return NotFound();
            }

            return Ok(korisniciTimovi);
        }

        // PUT: api/KorisniciTimovis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKorisniciTimovi(int id, KorisniciTimovi korisniciTimovi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != korisniciTimovi.KorisniciTimoviID)
            {
                return BadRequest();
            }

            db.Entry(korisniciTimovi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisniciTimoviExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/KorisniciTimovis
        [ResponseType(typeof(KorisniciTimovi))]
        public IHttpActionResult PostKorisniciTimovi(KorisniciTimovi korisniciTimovi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KorisniciTimovi.Add(korisniciTimovi);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = korisniciTimovi.KorisniciTimoviID }, korisniciTimovi);
        }

        // DELETE: api/KorisniciTimovis/5
        [ResponseType(typeof(KorisniciTimovi))]
        public IHttpActionResult DeleteKorisniciTimovi(int id)
        {
            KorisniciTimovi korisniciTimovi = db.KorisniciTimovi.Find(id);
            if (korisniciTimovi == null)
            {
                return NotFound();
            }

            db.KorisniciTimovi.Remove(korisniciTimovi);
            db.SaveChanges();

            return Ok(korisniciTimovi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KorisniciTimoviExists(int id)
        {
            return db.KorisniciTimovi.Count(e => e.KorisniciTimoviID == id) > 0;
        }
    }
}