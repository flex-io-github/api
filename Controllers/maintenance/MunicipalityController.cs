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
    public class MunicipalityController : Controller
    {
        Entities.DataContext dbContext;

        public MunicipalityController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/municipality
        [HttpGet]
        public IEnumerable<municipality> Get()
        {
            return dbContext.municipality.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.municipality.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/municipality/5
        [HttpGet("{id}")]
        public municipality Get(int id)
        {
            return dbContext.municipality.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/municipality
        [HttpPost]
        public municipality Post([FromBody]municipality value)
        {
            dbContext.municipality.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/municipality/5
        [HttpPut("{id}")]
        public municipality Put(int id, [FromBody]municipality value)
        {
            var entity = dbContext.municipality.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
            entity.name = value.name;
            entity.is_active = value.is_active;
            dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public municipality Delete(int id)
        {
            var entity = dbContext.municipality.Where(t => t.id == id).FirstOrDefault();
            dbContext.municipality.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
