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
    public class CarsController : ApiController
    {
        static private DriversEntities db = new DriversEntities();
        private readonly DbSet<Car> dbSet = db.Car;

        // GET api/Cars
        public IQueryable<Car> GetAddress()
        {
            return dbSet;
        }

        // GET api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult GetAddress(int id)
        {
            var type = dbSet.FirstOrDefault(e => e.ID == id);

            if (type == null)
                return NotFound();

            return Ok(type);
        }

        // POST api/Cars
        [ResponseType(typeof(Car))]
        public IHttpActionResult PostAddress(Car type)
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

        // PUT api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Car type)
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

        // DELETE api/Cars/5
        [ResponseType(typeof(Car))]
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