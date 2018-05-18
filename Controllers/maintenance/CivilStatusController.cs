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
    public class CivilStatusController : Controller
    {
        Entities.DataContext dbContext;

        public CivilStatusController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/civil_status
        [HttpGet]
        public IEnumerable<civil_status> Get()
        {
            return dbContext.civil_status.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.civil_status.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/civil_status/5
        [HttpGet("{id}")]
        public civil_status Get(int id)
        {
            return dbContext.civil_status.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/civil_status
        [HttpPost]
        public civil_status Post([FromBody]civil_status value)
        {
            dbContext.civil_status.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/civil_status/5
        [HttpPut("{id}")]
        public civil_status Put(int id, [FromBody]civil_status value)
        {
            var entity = dbContext.civil_status.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
			entity.name = value.name;
			entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public civil_status Delete(int id)
        {
            var entity = dbContext.civil_status.Where(t => t.id == id).FirstOrDefault();
            dbContext.civil_status.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
