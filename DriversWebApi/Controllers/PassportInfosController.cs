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
    public class PassportInfosController : ApiController
    {
        static private DriversEntities db = new DriversEntities();
        private readonly DbSet<PassportInfo> dbSet = db.PassportInfo;

        // GET api/PassportInfos
        public IQueryable<PassportInfo> GetAddress()
        {
            return dbSet;
        }

        // GET api/PassportInfos/5
        [ResponseType(typeof(PassportInfo))]
        public IHttpActionResult GetAddress(int id)
        {
            var type = dbSet.FirstOrDefault(e => e.ID == id);

            if (type == null)
                return NotFound();

            return Ok(type);
        }

        // POST api/PassportInfos
        [ResponseType(typeof(PassportInfo))]
        public IHttpActionResult PostAddress(PassportInfo type)
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

        // PUT api/PassportInfos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, PassportInfo type)
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

        // DELETE api/PassportInfos/5
        [ResponseType(typeof(PassportInfo))]
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