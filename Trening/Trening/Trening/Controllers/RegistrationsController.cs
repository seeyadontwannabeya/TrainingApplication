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
    public class RegistrationsController : ApiController
    {

        private TreningEntities2 db = new TreningEntities2();

        // GET: api/Registrations
        public IQueryable<Registration> GetRegistration()
        {
            return db.Registration;
        }

        // GET: api/Registrations/5
        [ResponseType(typeof(Registration))]
        public IHttpActionResult GetRegistration(int id)
        {
            Registration registration = db.Registration.Find(id);
            if (registration == null)
            {
                return NotFound();
            }

            return Ok(registration);
        }

        // PUT: api/Registrations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegistration(int id, Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registration.ID)
            {
                return BadRequest();
            }

            db.Entry(registration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationExists(id))
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

        // POST: api/Registrations
        [ResponseType(typeof(Registration))]
        public IHttpActionResult PostRegistration(Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Registration.Add(registration);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = registration.ID }, registration);
        }

        // DELETE: api/Registrations/5
        [ResponseType(typeof(Registration))]
        public IHttpActionResult DeleteRegistration(int id)
        {
            Registration registration = db.Registration.Find(id);
            if (registration == null)
            {
                return NotFound();
            }

            db.Registration.Remove(registration);
            db.SaveChanges();

            return Ok(registration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistrationExists(int id)
        {
            return db.Registration.Count(e => e.ID == id) > 0;
        }
    }
}