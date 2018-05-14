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
    public class PayrollPeriodsController : Controller
    {
        Entities.DataContext dbContext;
        public PayrollPeriodsController(Entities.DataContext dbContext) => this.dbContext = dbContext;

        //GET: api/payroll_periods
       [HttpGet]
        public IEnumerable<payroll_periods> Get()
        {
            return dbContext.payroll_periods.ToList();

        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.payroll_periods.Where(x => x.is_active == true)
              .OrderBy(x => x.period_order)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/payroll_periods/5
        [HttpGet("{id}")]
        public payroll_periods Get(int id)
        {
            return dbContext.payroll_periods.Where(t => t.id == id).FirstOrDefault();
        }

        // POST: api/payroll_periods
        [HttpPost]
        public payroll_periods Post([FromBody]payroll_periods value)
        {
            dbContext.payroll_periods.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // PUT: api/payroll_periods/5
        [HttpPut("{id}")]
        public payroll_periods Put(int id, [FromBody]payroll_periods value)
        {
            var entity = dbContext.payroll_periods.Where(t => t.id == id).FirstOrDefault();
            entity.name = value.name;
            entity.is_active = value.is_active;
            entity.period_order = value.period_order;
            entity.company_id = value.company_id;
            entity.payroll_period_type_id = value.payroll_period_type_id;
            entity.is_regular_payroll_period = value.is_regular_payroll_period;
            entity.is_13th_month_pay = value.is_13th_month_pay;
            entity.is_final_pay = value.is_final_pay;
            entity.is_annualization = value.is_annualization;
            entity.is_special_payroll = value.is_special_payroll;
            dbContext.SaveChanges();
            return entity;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public payroll_periods Delete(int id)
        {
            var entity = dbContext.payroll_periods.Where(t => t.id == id).FirstOrDefault();
            dbContext.payroll_periods.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}