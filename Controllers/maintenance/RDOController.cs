using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Enums;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RDOController : Controller
    {
        Entities.DataContext dbContext;
        public RDOController(Entities.DataContext dbContext) => this.dbContext = dbContext;

        //GET: api/rdo
       [HttpGet]
        public IEnumerable<rdo> Get()
        {
            return dbContext.rdo.ToList();

        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.rdo.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/rdo/5
        [HttpGet("{id}")]
        public rdo Get(int id)
        {
            return dbContext.rdo.Where(t => t.id == id).FirstOrDefault();
        }

        // POST: api/rdo
        [HttpPost]
        public rdo Post([FromBody]rdo value)
        {
            dbContext.rdo.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // PUT: api/rdo/5
        [HttpPut("{id}")]
        public rdo Put(int id, [FromBody]rdo value)
        {
            var entity = dbContext.rdo.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
            entity.name = value.name;
            entity.is_active = value.is_active;
            dbContext.SaveChanges();
            return entity;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public rdo Delete(int id)
        {
            var entity = dbContext.rdo.Where(t => t.id == id).FirstOrDefault();
            dbContext.rdo.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}