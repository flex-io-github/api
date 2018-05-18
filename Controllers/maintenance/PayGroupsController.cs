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
    public class PayGroupsController : Controller
    {
        Entities.DataContext dbContext;

        public PayGroupsController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/pay_groups
        [HttpGet]
        public IEnumerable<pay_groups> Get()
        {
            return dbContext.pay_groups.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.pay_groups.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/pay_groups/5
        [HttpGet("{id}")]
        public pay_groups Get(int id)
        {
            return dbContext.pay_groups.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/pay_groups
        [HttpPost]
        public pay_groups Post([FromBody]pay_groups value)
        {
            dbContext.pay_groups.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/pay_groups/5
        [HttpPut("{id}")]
        public pay_groups Put(int id, [FromBody]pay_groups value)
        {
            var entity = dbContext.pay_groups.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
			entity.name = value.name;
			entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public pay_groups Delete(int id)
        {
            var entity = dbContext.pay_groups.Where(t => t.id == id).FirstOrDefault();
            dbContext.pay_groups.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
