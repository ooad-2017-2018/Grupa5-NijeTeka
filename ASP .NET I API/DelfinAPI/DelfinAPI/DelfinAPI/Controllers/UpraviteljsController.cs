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
    public class UpraviteljsController : ApiController
    {
        private DelfinModel db = new DelfinModel();

        // GET: api/Upraviteljs
        public IQueryable<Upravitelj> GetUpravitelj()
        {
            return db.Upravitelj;
        }

        // GET: api/Upraviteljs/5
        [ResponseType(typeof(Upravitelj))]
        public IHttpActionResult GetUpravitelj(int id)
        {
            Upravitelj upravitelj = db.Upravitelj.Find(id);
            if (upravitelj == null)
            {
                return NotFound();
            }

            return Ok(upravitelj);
        }

        // PUT: api/Upraviteljs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUpravitelj(int id, Upravitelj upravitelj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != upravitelj.upraviteljID)
            {
                return BadRequest();
            }

            db.Entry(upravitelj).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UpraviteljExists(id))
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

        // POST: api/Upraviteljs
        [ResponseType(typeof(Upravitelj))]
        public IHttpActionResult PostUpravitelj(Upravitelj upravitelj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Upravitelj.Add(upravitelj);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = upravitelj.upraviteljID }, upravitelj);
        }

        // DELETE: api/Upraviteljs/5
        [ResponseType(typeof(Upravitelj))]
        public IHttpActionResult DeleteUpravitelj(int id)
        {
            Upravitelj upravitelj = db.Upravitelj.Find(id);
            if (upravitelj == null)
            {
                return NotFound();
            }

            db.Upravitelj.Remove(upravitelj);
            db.SaveChanges();

            return Ok(upravitelj);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UpraviteljExists(int id)
        {
            return db.Upravitelj.Count(e => e.upraviteljID == id) > 0;
        }
    }
}