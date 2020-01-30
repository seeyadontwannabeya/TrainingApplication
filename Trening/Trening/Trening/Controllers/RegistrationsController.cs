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
using Trening.Library;

namespace Trening.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class RegistrationsController : ApiController
    {
        private TreningEntities db = new TreningEntities();
        private LoginUtility loginUtil = new LoginUtility();
        [Route("login")]
        [HttpPost]
        public AccessTokenViewModel Login(UserLoginModel userLogin)
        {
            var tokenString = loginUtil.Login(userLogin.username, userLogin.password);

            if (tokenString != string.Empty)
            {
                var expireDate = DateTime.Now.AddHours(1);
                db.accesstokens.Add(new accesstokens { token = tokenString, expires = expireDate, created = DateTime.Now });
                db.SaveChanges();

                return new AccessTokenViewModel { accessToken = tokenString, expireDate = expireDate };
            }
            else
            {
                return null;
            }
        }

        // GET: api/Registrations
        public IQueryable<Login> GetRegistration()
        {
            return db.Login;
        }

        // GET: api/Registrations/5
        [ResponseType(typeof(Login))]
        public IHttpActionResult GetRegistration(int id)
        {
            Login registration = db.Login.Find(id);
            if (registration == null)
            {
                return NotFound();
            }
            return Ok(registration);
        }

        // PUT: api/Registrations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegistration(int id, Login registration)
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
        [ResponseType(typeof(Login))]
        public IHttpActionResult PostRegistration(Login registration)
        {
            //var usr = new UserValues();
            //usr.Login = new Login();
            //usr.Login.Email = registration.Email;
            //usr.Login.Pasword = registration.Pasword;
            
            //foreach (var obj in registration.UserValues)
            //{
            //    usr.Activityfactor = obj.Activityfactor;
            //    usr.Age = obj.Age;
            //    usr.Date = obj.Date;
            //    usr.Height = obj.Height;
            //    usr.ID = obj.ID;
            //    usr.Weight = obj.Weight;
            //    usr.Trainingexperience = "Hej";
            //    usr.KcalResult = 123;
            //    usr.Kcalplusminus = 123;
 
                
            //}
            //Console.WriteLine(usr);
            
            //registration.UserValues[0]
            //uservalues.LoginID = registration.ID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Login.Add(registration);
            //usr.Login = registration;
            //Console.WriteLine(registration);
            //db.UserValues.Add(usr);
            db.SaveChanges();
            
            return CreatedAtRoute("DefaultApi", new { id = registration.ID }, registration);
        }

        // DELETE: api/Registrations/5
        [ResponseType(typeof(Login))]
        public IHttpActionResult DeleteRegistration(int id)
        {
            Login registration = db.Login.Find(id);
            if (registration == null)
            {
                return NotFound();
            }

            db.Login.Remove(registration);
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
            return db.Login.Count(e => e.ID == id) > 0;
        }
    }
}