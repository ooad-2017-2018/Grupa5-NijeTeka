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
    public class RadnikSpasController : ApiController
    {
        private DelfinModel db = new DelfinModel();

        // GET: api/RadnikSpas
        public IQueryable<RadnikSpa> GetRadnikSpa()
        {
            return db.RadnikSpa;
        }

        // GET: api/RadnikSpas/5
        [ResponseType(typeof(RadnikSpa))]
        public IHttpActionResult GetRadnikSpa(int id)
        {
            RadnikSpa radnikSpa = db.RadnikSpa.Find(id);
            if (radnikSpa == null)
            {
                return NotFound();
            }

            return Ok(radnikSpa);
        }

        // PUT: api/RadnikSpas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRadnikSpa(int id, RadnikSpa radnikSpa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != radnikSpa.RadnikSpaID)
            {
                return BadRequest();
            }

            db.Entry(radnikSpa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RadnikSpaExists(id))
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

        // POST: api/RadnikSpas
        [ResponseType(typeof(RadnikSpa))]
        public IHttpActionResult PostRadnikSpa(RadnikSpa radnikSpa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RadnikSpa.Add(radnikSpa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = radnikSpa.RadnikSpaID }, radnikSpa);
        }

        // DELETE: api/RadnikSpas/5
        [ResponseType(typeof(RadnikSpa))]
        public IHttpActionResult DeleteRadnikSpa(int id)
        {
            RadnikSpa radnikSpa = db.RadnikSpa.Find(id);
            if (radnikSpa == null)
            {
                return NotFound();
            }

            db.RadnikSpa.Remove(radnikSpa);
            db.SaveChanges();

            return Ok(radnikSpa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RadnikSpaExists(int id)
        {
            return db.RadnikSpa.Count(e => e.RadnikSpaID == id) > 0;
        }
    }
}