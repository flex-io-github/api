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
    public class CostCentersController : Controller
    {
        Entities.DataContext dbContext;

        public CostCentersController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/cost_centers
        [HttpGet]
        public IEnumerable<cost_centers> Get()
        {
            return dbContext.cost_centers.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.cost_centers.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/cost_centers/5
        [HttpGet("{id}")]
        public cost_centers Get(int id)
        {
            return dbContext.cost_centers.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/cost_centers
        [HttpPost]
        public cost_centers Post([FromBody]cost_centers value)
        {
            dbContext.cost_centers.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/cost_centers/5
        [HttpPut("{id}")]
        public cost_centers Put(int id, [FromBody]cost_centers value)
        {
            var entity = dbContext.cost_centers.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
			entity.name = value.name;
			entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public cost_centers Delete(int id)
        {
            var entity = dbContext.cost_centers.Where(t => t.id == id).FirstOrDefault();
            dbContext.cost_centers.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
