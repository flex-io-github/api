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
    public class DepartmentsController : Controller
    {
        Entities.DataContext dbContext;

        public DepartmentsController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/departments
        [HttpGet]
        public IEnumerable<departments> Get()
        {
            return dbContext.departments.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.departments.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/departments/5
        [HttpGet("{id}")]
        public departments Get(int id)
        {
            return dbContext.departments.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/departments
        [HttpPost]
        public departments Post([FromBody]departments value)
        {
            dbContext.departments.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/departments/5
        [HttpPut("{id}")]
        public departments Put(int id, [FromBody]departments value)
        {
            var entity = dbContext.departments.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
			entity.name = value.name;
			entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public departments Delete(int id)
        {
            var entity = dbContext.departments.Where(t => t.id == id).FirstOrDefault();
            dbContext.departments.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
