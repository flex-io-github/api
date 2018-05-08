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
    public class EmploymentTypesController : Controller
    {
        Entities.DataContext dbContext;

        public EmploymentTypesController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/employment_types
        [HttpGet]
        public IEnumerable<employment_types> Get()
        {
            return dbContext.employment_types.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.employment_types.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/employment_types/5
        [HttpGet("{id}")]
        public employment_types Get(int id)
        {
            return dbContext.employment_types.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/employment_types
        [HttpPost]
        public employment_types Post([FromBody]employment_types value)
        {
            dbContext.employment_types.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/employment_types/5
        [HttpPut("{id}")]
        public employment_types Put(int id, [FromBody]employment_types value)
        {
            var entity = dbContext.employment_types.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
			entity.name = value.name;
			entity.is_active = value.is_active;
			entity.is_process = value.is_process;
			entity.is_temporary = value.is_temporary;
			entity.is_probation = value.is_probation;
			entity.is_contractual = value.is_contractual;
			entity.is_project_based = value.is_project_based;
			entity.is_outsourced = value.is_outsourced;
			entity.is_absorbed = value.is_absorbed;
			entity.is_regular = value.is_regular;
			entity.is_resigned = value.is_resigned;
			entity.is_terminated = value.is_terminated;
			entity.is_retired = value.is_retired;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public employment_types Delete(int id)
        {
            var entity = dbContext.employment_types.Where(t => t.id == id).FirstOrDefault();
            dbContext.employment_types.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
