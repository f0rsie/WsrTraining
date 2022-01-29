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
    public class AddressesController : ApiController
    {
        static private DriversEntities db = new DriversEntities();
        private readonly DbSet<Address> dbSet = db.Address;

        // GET api/Addresses
        public IQueryable<Address> GetAddress()
        {
            return dbSet;
        }

        // GET api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult GetAddress(int id)
        {
            var type = dbSet.FirstOrDefault(e => e.ID == id);

            if (type == null)
                return NotFound();

            return Ok(type);
        }

        // POST api/Addresses
        [ResponseType(typeof(Address))]
        public IHttpActionResult PostAddress(Address type)
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

        // PUT api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Address type)
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

        // DELETE api/Addresses/5
        [ResponseType(typeof(Address))]
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