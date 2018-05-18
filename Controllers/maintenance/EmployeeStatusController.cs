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
    public class EmployeeStatusController : Controller
    {
        Entities.DataContext dbContext;

        public EmployeeStatusController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/EmployeeStatus
        [HttpGet]
        public IEnumerable<employee_status> Get()
        {
            return dbContext.employee_status.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.employee_status.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/EmployeeStatus/5
        [HttpGet("{id}")]
        public employee_status Get(int id)
        {
            return dbContext.employee_status.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/EmployeeStatus
        [HttpPost]
        public employee_status Post([FromBody]employee_status value)
        {
            dbContext.employee_status.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/EmployeeStatus/5
        [HttpPut("{id}")]
        public employee_status Put(int id, [FromBody]employee_status value)
        {
            var entity = dbContext.employee_status.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
            entity.name = value.name;
            entity.is_active = value.is_active;
            dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public employee_status Delete(int id)
        {
            var entity = dbContext.employee_status.Where(t => t.id == id).FirstOrDefault();
            dbContext.employee_status.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
