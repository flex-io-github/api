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
    public class PositionController : Controller
    {
        Entities.DataContext dbContext;
        public PositionController(Entities.DataContext dbContext) => this.dbContext = dbContext;

        //GET: api/positions
       [HttpGet]
        public IEnumerable<positions> Get()
        {
            return dbContext.positions.ToList();

        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.positions.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/positions/5
        [HttpGet("{id}")]
        public positions Get(int id)
        {
            return dbContext.positions.Where(t => t.id == id).FirstOrDefault();
        }

        // POST: api/positions
        [HttpPost]
        public positions Post([FromBody]positions value)
        {
            dbContext.positions.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // PUT: api/positions/5
        [HttpPut("{id}")]
        public positions Put(int id, [FromBody]positions value)
        {
            var entity = dbContext.positions.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
            entity.name = value.name;
            entity.is_active = value.is_active;
            dbContext.SaveChanges();
            return entity;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public positions Delete(int id)
        {
            var entity = dbContext.positions.Where(t => t.id == id).FirstOrDefault();
            dbContext.positions.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}