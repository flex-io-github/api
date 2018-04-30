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
    public class EmployeeDependentsController : Controller
    {
        Entities.DataContext dbContext;

        public EmployeeDependentsController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/employee_dependents
        [HttpGet]
        public IEnumerable<employee_dependents> Get()
        {
            return dbContext.employee_dependents.ToList();
        }

        // [HttpGet("LookUp")]
        // public dynamic GetLookup()
        // {
            // return dbContext.employee_dependents.Where(x => x.is_active == true)
              // .Select(x => new
              // {
                  // key = x.id,
                  // text = x.name,
              // }).ToList();
        // }

        // GET: api/employee_dependents/5
        [HttpGet("{id}")]
        public employee_dependents Get(int id)
        {
            return dbContext.employee_dependents.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/employee_dependents
        [HttpPost]
        public employee_dependents Post([FromBody]employee_dependents value)
        {
            dbContext.employee_dependents.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/employee_dependents/5
        [HttpPut("{id}")]
        public employee_dependents Put(int id, [FromBody]employee_dependents value)
        {
            var entity = dbContext.employee_dependents.Where(t => t.id == id).FirstOrDefault();
            entity.first_name = value.first_name;
			entity.middle_name = value.middle_name;
			entity.last_name = value.last_name;
			entity.date_of_birth = value.date_of_birth;
			entity.relationship_id = value.relationship_id;
			entity.is_mentally_physically_incapacitated = value.is_mentally_physically_incapacitated;
            entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public employee_dependents Delete(int id)
        {
            var entity = dbContext.employee_dependents.Where(t => t.id == id).FirstOrDefault();
            dbContext.employee_dependents.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
