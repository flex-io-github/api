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
    public class CurrenciesController : Controller
    {
        Entities.DataContext dbContext;

        public CurrenciesController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/currencies
        [HttpGet]
        public IEnumerable<currencies> Get()
        {
            return dbContext.currencies.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.currencies.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/currencies/5
        [HttpGet("{id}")]
        public currencies Get(int id)
        {
            return dbContext.currencies.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/currencies
        [HttpPost]
        public currencies Post([FromBody]currencies value)
        {
            dbContext.currencies.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/currencies/5
        [HttpPut("{id}")]
        public currencies Put(int id, [FromBody]currencies value)
        {
            var entity = dbContext.currencies.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
			entity.name = value.name;
			entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public currencies Delete(int id)
        {
            var entity = dbContext.currencies.Where(t => t.id == id).FirstOrDefault();
            dbContext.currencies.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
