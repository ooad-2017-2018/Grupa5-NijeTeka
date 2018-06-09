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
    public class KorisniciPojedincisController : ApiController
    {
        private DelfinModel db = new DelfinModel();

        // GET: api/KorisniciPojedincis
        public IQueryable<KorisniciPojedinci> GetKorisniciPojedinci()
        {
            return db.KorisniciPojedinci;
        }

        // GET: api/KorisniciPojedincis/5
        [ResponseType(typeof(KorisniciPojedinci))]
        public IHttpActionResult GetKorisniciPojedinci(int id)
        {
            KorisniciPojedinci korisniciPojedinci = db.KorisniciPojedinci.Find(id);
            if (korisniciPojedinci == null)
            {
                return NotFound();
            }

            return Ok(korisniciPojedinci);
        }

        // PUT: api/KorisniciPojedincis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKorisniciPojedinci(int id, KorisniciPojedinci korisniciPojedinci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != korisniciPojedinci.KorisniciPojedinciID)
            {
                return BadRequest();
            }

            db.Entry(korisniciPojedinci).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisniciPojedinciExists(id))
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

        // POST: api/KorisniciPojedincis
        [ResponseType(typeof(KorisniciPojedinci))]
        public IHttpActionResult PostKorisniciPojedinci(KorisniciPojedinci korisniciPojedinci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KorisniciPojedinci.Add(korisniciPojedinci);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = korisniciPojedinci.KorisniciPojedinciID }, korisniciPojedinci);
        }

        // DELETE: api/KorisniciPojedincis/5
        [ResponseType(typeof(KorisniciPojedinci))]
        public IHttpActionResult DeleteKorisniciPojedinci(int id)
        {
            KorisniciPojedinci korisniciPojedinci = db.KorisniciPojedinci.Find(id);
            if (korisniciPojedinci == null)
            {
                return NotFound();
            }

            db.KorisniciPojedinci.Remove(korisniciPojedinci);
            db.SaveChanges();

            return Ok(korisniciPojedinci);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KorisniciPojedinciExists(int id)
        {
            return db.KorisniciPojedinci.Count(e => e.KorisniciPojedinciID == id) > 0;
        }
    }
}