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
    public class EmployeeIdentificationsController : Controller
    {
        Entities.DataContext dbContext;

        public EmployeeIdentificationsController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/employee_identifications
        [HttpGet]
        public IEnumerable<employee_identifications> Get()
        {
            return dbContext.employee_identifications.ToList();
        }

        // [HttpGet("LookUp")]
        // public dynamic GetLookup()
        // {
            // return dbContext.employee_identifications.Where(x => x.is_active == true)
              // .Select(x => new
              // {
                  // key = x.id,
                  // text = x.name,
              // }).ToList();
        // }

        // GET: api/employee_identifications/5
        [HttpGet("{id}")]
        public employee_identifications Get(int id)
        {
            return dbContext.employee_identifications.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/employee_identifications
        [HttpPost]
        public employee_identifications Post([FromBody]employee_identifications value)
        {
            dbContext.employee_identifications.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/employee_identifications/5
        [HttpPut("{id}")]
        public employee_identifications Put(int id, [FromBody]employee_identifications value)
        {
            var entity = dbContext.employee_identifications.Where(t => t.id == id).FirstOrDefault();
            entity.employee_id = value.employee_id;
			entity.identification_type_id = value.identification_type_id;
			entity.number = value.number;
			entity.effective_date = value.effective_date;
			entity.expiry_date = value.expiry_date;
			entity.issuer = value.issuer;
			entity.place_coutry_of_issue = value.place_coutry_of_issue;
			entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public employee_identifications Delete(int id)
        {
            var entity = dbContext.employee_identifications.Where(t => t.id == id).FirstOrDefault();
            dbContext.employee_identifications.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
