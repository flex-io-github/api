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
    public class DeMinimisController : Controller
    {
        Entities.DataContext dbContext;

        public DeMinimisController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/de_minimis
        [HttpGet]
        public IEnumerable<de_minimis> Get()
        {
            return dbContext.de_minimis.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.de_minimis.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/de_minimis/5
        [HttpGet("{id}")]
        public de_minimis Get(int id)
        {
            return dbContext.de_minimis.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/de_minimis
        [HttpPost]
        public de_minimis Post([FromBody]de_minimis value)
        {
            dbContext.de_minimis.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/de_minimis/5
        [HttpPut("{id}")]
        public de_minimis Put(int id, [FromBody]de_minimis value)
        {
            var entity = dbContext.de_minimis.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
			entity.name = value.name;
            entity.ceiling = value.ceiling;
            entity.de_minimis_unit_id = value.de_minimis_unit_id;
            entity.time_unit_id = value.time_unit_id;
            entity.description = value.description;
            entity.remarks = value.remarks;
            entity.pay_tax_type_id = value.pay_tax_type_id;
			entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public de_minimis Delete(int id)
        {
            var entity = dbContext.de_minimis.Where(t => t.id == id).FirstOrDefault();
            dbContext.de_minimis.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
