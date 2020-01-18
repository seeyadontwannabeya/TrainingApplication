using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Trening.Models;
using System.Web.Http.Description;

namespace Trening.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class CalculatorController : ApiController
    {
        private TreningEntities2 db = new TreningEntities2();

        // GET: api/Registrati/5
        [ResponseType(typeof(Registration))]
        public IHttpActionResult GetRegistration(int id)
        {
            Registration registration = db.Registration.Find(id);
            if (registration == null)
            {
                return NotFound();
            }

            return Ok(calc(registration.Age, registration.Activity, registration.Height, registration.Weight));
        }

        public double calc(int? _age, Decimal? _activity, Decimal? _height, Decimal? _weight)
        {
            double activity = double.Parse(_activity.ToString());
            double height = double.Parse(_height.ToString());
            double age = double.Parse(_age.ToString());
            double weight = double.Parse(_weight.ToString());

            double bEE = 66.5 + (13.75 * weight) + (5.003 * height) - (6.775 * age);
            double activityAndBEE = bEE + activity;
            




            return activityAndBEE;
        }
    }

}
