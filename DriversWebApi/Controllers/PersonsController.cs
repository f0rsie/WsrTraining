using DriversWebApi.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace DriversWebApi.Controllers
{
    public class PersonsController : ApiController
    {
        static private DriversEntities db = new DriversEntities();
        private readonly DbSet<Person> dbSet = db.Person;

        // GET api/Persons
        public IQueryable<Person> GetAddress()
        {
            return dbSet;
        }

        // GET api/Persons/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult GetAddress(int id)
        {
            var type = dbSet.FirstOrDefault(e => e.ID == id);

            if (type == null)
                return NotFound();

            return Ok(type);
        }

        // POST api/Persons
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostAddress(Person type)
        {
            if (type == null)
                return BadRequest();

            dbSet.Add(type);

            try
            {
                db.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/Persons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Person type)
        {
            if (type.ID != id)
                return BadRequest();

            dbSet.AddOrUpdate(type);

            try
            {
                db.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/Persons/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeleteAddress(int id)
        {
            var type = dbSet.FirstOrDefault(e => e.ID == id);

            if (type == null)
                return NotFound();

            dbSet.Remove(type);

            try
            {
                db.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}