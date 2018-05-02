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
    public class SuffixController : Controller
    {
        Entities.DataContext dbContext;

        public SuffixController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/suffix
        [HttpGet]
        public IEnumerable<suffix> Get()
        {
            return dbContext.suffix.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.suffix.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/suffix/5
        [HttpGet("{id}")]
        public suffix Get(int id)
        {
            return dbContext.suffix.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/suffix
        [HttpPost]
        public suffix Post([FromBody]suffix value)
        {
            dbContext.suffix.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/suffix/5
        [HttpPut("{id}")]
        public suffix Put(int id, [FromBody]suffix value)
        {
            var entity = dbContext.suffix.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
			entity.name = value.name;
			entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public suffix Delete(int id)
        {
            var entity = dbContext.suffix.Where(t => t.id == id).FirstOrDefault();
            dbContext.suffix.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
