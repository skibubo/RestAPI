using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleRestServer.Models;
using System.Collections;
namespace SimpleRestServer.Controllers
{
    public class PersonController : ApiController
    {
        // GET: api/Persons
        public ArrayList Get()
        {
            PersonPersistence pp = new PersonPersistence();
            return pp.getPersons();
        }

        // GET: api/Person/5
        public Person Get(int id)
        {
            PersonPersistence pp = new PersonPersistence();
            Person person = pp.getPerson(id);

            //person.Id =id;
            //person.LastName = "";
            //person.FirstName = "";
            //person.PayRate = 0;
            //person.StartDate = DateTime.Parse("12/12/2022");
            //person.EndDate = DateTime.Parse("12/12/3022");

            return person;
        }

        // POST: api/Person
        public HttpResponseMessage Post([FromBody]Person value)
        {
            PersonPersistence pp = new PersonPersistence();
            int id;
            id = pp.savePerson(value);
            value.Id = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("person/{0}", id));
            return response; 
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
