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
    public class EmployeeSpouseController : Controller
    {
        Entities.DataContext dbContext;

        public EmployeeSpouseController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/employee_spouse
        [HttpGet]
        public IEnumerable<employee_spouse> Get()
        {
            return dbContext.employee_spouse.ToList();
        }

        // [HttpGet("LookUp")]
        // public dynamic GetLookup()
        // {
            // return dbContext.employee_spouse.Where(x => x.is_active == true)
              // .Select(x => new
              // {
                  // key = x.id,
                  // text = x.name,
              // }).ToList();
        // }

        // GET: api/employee_spouse/5
        [HttpGet("{id}")]
        public employee_spouse Get(int id)
        {
            return dbContext.employee_spouse.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/employee_spouse
        [HttpPost]
        public employee_spouse Post([FromBody]employee_spouse value)
        {
            dbContext.employee_spouse.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/employee_spouse/5
        [HttpPut("{id}")]
        public employee_spouse Put(int id, [FromBody]employee_spouse value)
        {
            var entity = dbContext.employee_spouse.Where(t => t.id == id).FirstOrDefault();
            entity.first_name = value.first_name;
			entity.middle_name = value.middle_name;
			entity.last_name = value.last_name;
			entity.tin = value.tin;
			entity.date_of_birth = value.date_of_birth;
			entity.contact_number = value.contact_number;
			entity.email_address = value.email_address;
			entity.is_claiming_exemptions = value.is_claiming_exemptions;
			entity.employer_name = value.employer_name;
			entity.employer_tin = value.employer_tin;
			entity.employment_status_id = value.employment_status_id;
			entity.employer_tin_branch = value.employer_tin_branch;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public employee_spouse Delete(int id)
        {
            var entity = dbContext.employee_spouse.Where(t => t.id == id).FirstOrDefault();
            dbContext.employee_spouse.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
