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
    public class DatasController : ApiController
    {
        static private DriversEntities db = new DriversEntities();
        private readonly DbSet<Data> dbSet = db.Data;

        // GET api/Datas
        public IQueryable<Data> GetAddress()
        {
            return dbSet;
        }

        // GET api/Datas/5
        [ResponseType(typeof(Data))]
        public IHttpActionResult GetAddress(int id)
        {
            var type = dbSet.FirstOrDefault(e => e.ID == id);

            if (type == null)
                return NotFound();

            return Ok(type);
        }

        // POST api/Datas
        [ResponseType(typeof(Data))]
        public IHttpActionResult PostAddress(Data type)
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

        // PUT api/Datas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Data type)
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

        // DELETE api/Datas/5
        [ResponseType(typeof(Data))]
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