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
    public class LocationsController : Controller
    {
        Entities.DataContext dbContext;

        public LocationsController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/locations
        [HttpGet]
        public IEnumerable<locations> Get()
        {
            return dbContext.locations.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.locations.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/locations/5
        [HttpGet("{id}")]
        public locations Get(int id)
        {
            return dbContext.locations.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/locations
        [HttpPost]
        public locations Post([FromBody]locations value)
        {
            dbContext.locations.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/locations/5
        [HttpPut("{id}")]
        public locations Put(int id, [FromBody]locations value)
        {
            var entity = dbContext.locations.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
			entity.name = value.name;
			entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public locations Delete(int id)
        {
            var entity = dbContext.locations.Where(t => t.id == id).FirstOrDefault();
            dbContext.locations.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
