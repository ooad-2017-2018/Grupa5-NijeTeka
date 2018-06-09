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
    public class RecepcionarsController : ApiController
    {
        private DelfinModel db = new DelfinModel();

        // GET: api/Recepcionars
        public IQueryable<Recepcionar> GetRecepcionar()
        {
            return db.Recepcionar;
        }

        // GET: api/Recepcionars/5
        [ResponseType(typeof(Recepcionar))]
        public IHttpActionResult GetRecepcionar(int id)
        {
            Recepcionar recepcionar = db.Recepcionar.Find(id);
            if (recepcionar == null)
            {
                return NotFound();
            }

            return Ok(recepcionar);
        }

        // PUT: api/Recepcionars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecepcionar(int id, Recepcionar recepcionar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recepcionar.RecepcionarID)
            {
                return BadRequest();
            }

            db.Entry(recepcionar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecepcionarExists(id))
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

        // POST: api/Recepcionars
        [ResponseType(typeof(Recepcionar))]
        public IHttpActionResult PostRecepcionar(Recepcionar recepcionar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recepcionar.Add(recepcionar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recepcionar.RecepcionarID }, recepcionar);
        }

        // DELETE: api/Recepcionars/5
        [ResponseType(typeof(Recepcionar))]
        public IHttpActionResult DeleteRecepcionar(int id)
        {
            Recepcionar recepcionar = db.Recepcionar.Find(id);
            if (recepcionar == null)
            {
                return NotFound();
            }

            db.Recepcionar.Remove(recepcionar);
            db.SaveChanges();

            return Ok(recepcionar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecepcionarExists(int id)
        {
            return db.Recepcionar.Count(e => e.RecepcionarID == id) > 0;
        }
    }
}