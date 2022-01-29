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
    public class FinesController : ApiController
    {
        static private DriversEntities db = new DriversEntities();
        private readonly DbSet<Fine> dbSet = db.Fine;

        // GET api/Fines
        public IQueryable<Fine> GetAddress()
        {
            return dbSet;
        }

        // GET api/Fines/5
        [ResponseType(typeof(Fine))]
        public IHttpActionResult GetAddress(int id)
        {
            var type = dbSet.FirstOrDefault(e => e.ID == id);

            if (type == null)
                return NotFound();

            return Ok(type);
        }

        // POST api/Fines
        [ResponseType(typeof(Fine))]
        public IHttpActionResult PostAddress(Fine type)
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

        // PUT api/Fines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Fine type)
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

        // DELETE api/Fines/5
        [ResponseType(typeof(Fine))]
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