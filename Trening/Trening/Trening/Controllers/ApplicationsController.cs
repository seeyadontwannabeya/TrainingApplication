using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http.Cors;
using System.Web.Http;
using System.Web.Http.Description;
using Trening.Models;

namespace Trening.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class ApplicationsController : ApiController
    {
        private TreningEntities2 db = new TreningEntities2();

        // GET: api/Applications
        public IQueryable<Registration> GetApplication()
        {
            return db.Registration;
        }

        // GET: api/Applications/5
        [ResponseType(typeof(Registration))]
        public IHttpActionResult GetApplication(int id)
        {
            Registration application = db.Registration.Find(id);
            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        // PUT: api/Applications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplication(int id, Registration application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != application.ID)
            {
                return BadRequest();
            }

            db.Entry(application).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
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

        // POST: api/Applications
        [ResponseType(typeof(Registration))]
        public IHttpActionResult PostApplication(Registration application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Registration.Add(application);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ApplicationExists(application.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = application.ID }, application);
        }

        // DELETE: api/Applications/5
        [ResponseType(typeof(Registration))]
        public IHttpActionResult DeleteApplication(int id)
        {
            Registration application = db.Registration.Find(id);
            if (application == null)
            {
                return NotFound();
            }

            db.Registration.Remove(application);
            db.SaveChanges();

            return Ok(application);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationExists(int id)
        {
            return db.Registration.Count(e => e.ID == id) > 0;
        }
    }
}