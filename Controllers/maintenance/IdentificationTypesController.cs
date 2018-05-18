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
    public class IdentificationTypesController : Controller
    {
        Entities.DataContext dbContext;

        public IdentificationTypesController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/identification_types
        [HttpGet]
        public IEnumerable<identification_types> Get()
        {
            return dbContext.identification_types.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.identification_types.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/identification_types/5
        [HttpGet("{id}")]
        public identification_types Get(int id)
        {
            return dbContext.identification_types.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/identification_types
        [HttpPost]
        public identification_types Post([FromBody]identification_types value)
        {
            dbContext.identification_types.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/identification_types/5
        [HttpPut("{id}")]
        public identification_types Put(int id, [FromBody]identification_types value)
        {
            var entity = dbContext.identification_types.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
			entity.name = value.name;
			entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public identification_types Delete(int id)
        {
            var entity = dbContext.identification_types.Where(t => t.id == id).FirstOrDefault();
            dbContext.identification_types.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
