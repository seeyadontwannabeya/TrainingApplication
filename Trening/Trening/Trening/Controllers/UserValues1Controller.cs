using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Trening.Models;

namespace Trening.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class UserValues1Controller : ApiController
    {
        private TreningEntities db = new TreningEntities();

        // GET: api/UserValues1
        //public IQueryable<UserValues> GetUserValues()
        //{
        //    return db.UserValues;
        //}

        //// GET: api/UserValues1/5
        //[ResponseType(typeof(UserValues))]
        //public IHttpActionResult GetUserValues(int id)
        //{
        //    UserValues userValues = db.UserValues.Find(id);
        //    if (userValues == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(userValues);
        //}

        // PUT: api/UserValues1/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUserValues(int id, UserValues userValues)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != userValues.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(userValues).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserValuesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/UserValues1
        //[ResponseType(typeof(UserValues))]
        //public IHttpActionResult PostUserValues(UserValues userValues)
        //{
            
        //    DateTime myDateTime = DateTime.Now;
        //    myDateTime.ToString("YYYY-MM-DD HH:MI:SS");
        //    userValues.Date = myDateTime;

        //    //DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.UserValues.Add(userValues);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = userValues.ID }, userValues);
        //}

        // DELETE: api/UserValues1/5
        //[ResponseType(typeof(UserValues))]
        //public IHttpActionResult DeleteUserValues(int id)
        //{
        //    UserValues userValues = db.UserValues.Find(id);
        //    if (userValues == null)
        //    {
        //        return NotFound();
        //    }

        //    db.UserValues.Remove(userValues);
        //    db.SaveChanges();

        //    return Ok(userValues);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool UserValuesExists(int id)
        //{
        //    return db.UserValues.Count(e => e.ID == id) > 0;
        //}
    }
}