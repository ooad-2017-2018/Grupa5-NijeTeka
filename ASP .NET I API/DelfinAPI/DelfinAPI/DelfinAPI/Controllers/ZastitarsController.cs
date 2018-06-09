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
    public class ZastitarsController : ApiController
    {
        private DelfinModel db = new DelfinModel();

        // GET: api/Zastitars
        public IQueryable<Zastitar> GetZastitar()
        {
            return db.Zastitar;
        }

        // GET: api/Zastitars/5
        [ResponseType(typeof(Zastitar))]
        public IHttpActionResult GetZastitar(int id)
        {
            Zastitar zastitar = db.Zastitar.Find(id);
            if (zastitar == null)
            {
                return NotFound();
            }

            return Ok(zastitar);
        }

        // PUT: api/Zastitars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZastitar(int id, Zastitar zastitar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zastitar.ZastitarID)
            {
                return BadRequest();
            }

            db.Entry(zastitar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZastitarExists(id))
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

        // POST: api/Zastitars
        [ResponseType(typeof(Zastitar))]
        public IHttpActionResult PostZastitar(Zastitar zastitar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zastitar.Add(zastitar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zastitar.ZastitarID }, zastitar);
        }

        // DELETE: api/Zastitars/5
        [ResponseType(typeof(Zastitar))]
        public IHttpActionResult DeleteZastitar(int id)
        {
            Zastitar zastitar = db.Zastitar.Find(id);
            if (zastitar == null)
            {
                return NotFound();
            }

            db.Zastitar.Remove(zastitar);
            db.SaveChanges();

            return Ok(zastitar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZastitarExists(int id)
        {
            return db.Zastitar.Count(e => e.ZastitarID == id) > 0;
        }
    }
}