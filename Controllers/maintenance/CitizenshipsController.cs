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
    public class CitizenshipsController : Controller
    {
        Entities.DataContext dbContext;

        public CitizenshipsController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/citizenships
        [HttpGet]
        public IEnumerable<citizenships> Get()
        {
            return dbContext.citizenships.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.citizenships.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/citizenships/5
        [HttpGet("{id}")]
        public citizenships Get(int id)
        {
            return dbContext.citizenships.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/citizenships
        [HttpPost]
        public citizenships Post([FromBody]citizenships value)
        {
            dbContext.citizenships.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/citizenships/5
        [HttpPut("{id}")]
        public citizenships Put(int id, [FromBody]citizenships value)
        {
            var entity = dbContext.citizenships.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
			entity.name = value.name;
			entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public citizenships Delete(int id)
        {
            var entity = dbContext.citizenships.Where(t => t.id == id).FirstOrDefault();
            dbContext.citizenships.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
