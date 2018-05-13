using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Enums;
using WebApi.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi
{
    
    
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        Entities.DataContext dbContext;

        public EmployeesController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        // GET: api/values

        //[HttpGet]
        //public IEnumerable<employee> Get()
        //{
        //    return dbContext.employees.ToList();
        //}

        [HttpGet]
        public IEnumerable<EmployeeList> Get()
        {
            
            var query = from x in dbContext.employees
                join y in dbContext.employee_status on x.employee_status_id equals y.id into z
                from sublist in z.DefaultIfEmpty()
                select new EmployeeList
                {
                    id = x.id,
                    employee_code = x.employee_code,
                    first_name = x.first_name,
                    last_name = x.last_name,
                    middle_name = x.middle_name,
                    prefix = x.prefix,
                    tfn = x.tfn,
                    mobile_number = x.mobile_number,
                    email_address = x.email_address,
                    date_of_birth = x.date_of_birth,
                    gender = x.gender_id == 0 ? String.Empty : (x.gender_id == 1 ? "Male" : "Female"),
                    work_type = "",
                    employee_status = sublist == null ? String.Empty : (sublist.display ?? String.Empty),
                    created_by = x.employee_code,
                    date_created = x.date_created,
                    modified_by = x.employee_code,
                    date_modified = x.date_modified,
                };

            return query.OrderBy(x => x.employee_code);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public employee Get(int id)
        {
            return dbContext.employees.Where(t => t.id == id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public employee Post([FromBody]employee value)
        {
            dbContext.employees.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public employee Put(int id, [FromBody]employee value)
        {
            var entity = dbContext.employees.Where(t => t.id == id).FirstOrDefault();
            entity.employee_code = value.employee_code;
            entity.first_name = value.first_name;
			entity.middle_name = value.middle_name;
            entity.last_name = value.last_name;
            entity.email_address = value.email_address;
            entity.mobile_number = value.mobile_number;
            entity.prefix = value.prefix;
            entity.suffix_id = value.suffix_id;
			entity.nickname = value.nickname;
            entity.date_of_birth = value.date_of_birth;
            entity.gender_id = value.gender_id;
            entity.employee_status_id = value.employee_status_id;
            entity.work_type_id = value.work_type_id;
            entity.tfn = value.tfn;
            entity.company_id = value.company_id;
            entity.bank_id = value.bank_id;
            entity.tin = value.tin;
			entity.hdmf_id = value.hdmf_id;
			entity.pag_ibig_number = value.pag_ibig_number;
			entity.sss_number = value.sss_number;
			entity.phic_number = value.phic_number;
            entity.telephone_number = value.telephone_number;
            entity.rdo_id = value.rdo_id;
            entity.position_id = value.position_id;
            entity.alphanumeric_tax_code_id = value.alphanumeric_tax_code_id;
            entity.civil_status_id = value.civil_status_id;
            entity.employee_spouse_id = value.employee_spouse_id;
			entity.place_of_birth = value.place_of_birth;
			entity.mothers_maiden_name = value.mothers_maiden_name;
			entity.fathers_name = value.fathers_name;
			entity.citizenship_id = value.citizenship_id;
			entity.mobile_number = value.mobile_number;
			entity.fax_number = value.fax_number;
			entity.employment_type_id = value.employment_type_id;
			entity.department_id = value.department_id;
			entity.cost_center_id = value.cost_center_id;
			entity.location_id = value.location_id;
			entity.supervisor_id = value.supervisor_id;
			entity.is_active = value.is_active;
			entity.is_union = value.is_union;
			entity.pay_group_id = value.pay_group_id;
			entity.payment_type_id = value.payment_type_id;
			entity.payroll_frequency_id = value.payroll_frequency_id;
            entity.parameter_id = value.parameter_id;
            entity.date_effective = value.date_effective;
            entity.time_source_id = value.time_source_id;
            dbContext.SaveChanges();
            return entity;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public employee Delete(int id)
        {
            var entity = dbContext.employees.Where(t => t.id == id).FirstOrDefault();
            dbContext.employees.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
