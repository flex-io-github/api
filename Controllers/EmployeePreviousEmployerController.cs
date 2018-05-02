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
    public class EmployeePreviousEmployerController : Controller
    {
        Entities.DataContext dbContext;
        public EmployeePreviousEmployerController(Entities.DataContext dbContext) => this.dbContext = dbContext;

        //GET: api/employee_previous_employer
       [HttpGet]
        public IEnumerable<employee_previous_employer> Get()
        {
            return dbContext.employee_previous_employer.ToList();

        }

        // [HttpGet("LookUp")]
        // public dynamic GetLookup()
        // {
            // return dbContext.employee_previous_employer.Where(x => x.is_active == true)
              // .Select(x => new
              // {
                  // key = x.id,
                  // text = x.name,
              // }).ToList();
        // }

        // GET: api/employee_previous_employer/5
        [HttpGet("{id}")]
        public employee_previous_employer Get(int id)
        {
            return dbContext.employee_previous_employer.Where(t => t.id == id).FirstOrDefault();
        }

        // POST: api/employee_previous_employer
        [HttpPost]
        public employee_previous_employer Post([FromBody]employee_previous_employer value)
        {
            dbContext.employee_previous_employer.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // PUT: api/employee_previous_employer/5
        [HttpPut("{id}")]
        public employee_previous_employer Put(int id, [FromBody]employee_previous_employer value)
        {
            var entity = dbContext.employee_previous_employer.Where(t => t.id == id).FirstOrDefault();
            entity.address = value.address;
			entity.zip_code = value.zip_code;
			entity.tin = value.tin;
			entity.year = value.year;
			entity._25_gross_taxable_compensation_income = value._25_gross_taxable_compensation_income;
			entity._27_premium_paid = value._27_premium_paid;
			entity._31_total_tax_withheld = value._31_total_tax_withheld;
			entity._37_13th_month_pay_and_other_benefits = value._37_13th_month_pay_and_other_benefits;
			entity._38_de_minimis_benefits = value._38_de_minimis_benefits;
			entity._39_contributions_and_union_dues = value._39_contributions_and_union_dues;
			entity._40_salaries_and_compensation = value._40_salaries_and_compensation;
			entity._51_taxable_13th_month_pay_and_other_benefits = value._51_taxable_13th_month_pay_and_other_benefits;
            dbContext.SaveChanges();
            return entity;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public employee_previous_employer Delete(int id)
        {
            var entity = dbContext.employee_previous_employer.Where(t => t.id == id).FirstOrDefault();
            dbContext.employee_previous_employer.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}