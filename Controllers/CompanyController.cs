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
    public class CompanyController : Controller
    {
        Entities.DataContext dbContext;
        public CompanyController(Entities.DataContext dbContext) => this.dbContext = dbContext;

        //GET: api/company
       [HttpGet]
        public IEnumerable<company> Get()
        {
            return dbContext.company.ToList();

        }

        // GET: api/company/5
        [HttpGet("{id}")]
        public company Get(int id)
        {
            return dbContext.company.Where(t => t.id == id).FirstOrDefault();
        }

        // POST: api/company
        [HttpPost]
        public company Post([FromBody]company value)
        {
            dbContext.company.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // PUT: api/company/5
        [HttpPut("{id}")]
        public company Put(int id, [FromBody]company value)
        {
            var entity = dbContext.company.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
            entity.register_name = value.register_name;
            entity.telephone_number = value.telephone_number;
            entity.tin = value.tin;
            entity.rdo_id = value.rdo_id;
            entity.line_of_business = value.line_of_business;
            entity.bank_id = value.bank_id;
            entity.is_active = value.is_active;
            dbContext.SaveChanges();
            return entity;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public company Delete(int id)
        {
            var entity = dbContext.company.Where(t => t.id == id).FirstOrDefault();
            dbContext.company.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}