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
    public class AlphanumericTaxCodesController : Controller
    {
        Entities.DataContext dbContext;
        public AlphanumericTaxCodesController(Entities.DataContext dbContext) => this.dbContext = dbContext;

        //GET: api/alphanumeric_tax_codes
       [HttpGet]
        public IEnumerable<alphanumeric_tax_codes> Get()
        {
            return dbContext.alphanumeric_tax_codes.ToList();

        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.alphanumeric_tax_codes.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/alphanumeric_tax_codes/5
        [HttpGet("{id}")]
        public alphanumeric_tax_codes Get(int id)
        {
            return dbContext.alphanumeric_tax_codes.Where(t => t.id == id).FirstOrDefault();
        }

        // POST: api/alphanumeric_tax_codes
        [HttpPost]
        public alphanumeric_tax_codes Post([FromBody]alphanumeric_tax_codes value)
        {
            dbContext.alphanumeric_tax_codes.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // PUT: api/alphanumeric_tax_codes/5
        [HttpPut("{id}")]
        public alphanumeric_tax_codes Put(int id, [FromBody]alphanumeric_tax_codes value)
        {
            var entity = dbContext.alphanumeric_tax_codes.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
            entity.name = value.name;
			entity.rate = value.rate;
			entity.is_ewt = value.is_ewt;
			entity.is_fb_tax = value.is_fb_tax;
			entity.is_final_tax = value.is_final_tax;
            entity.is_active = value.is_active;
            dbContext.SaveChanges();
            return entity;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public alphanumeric_tax_codes Delete(int id)
        {
            var entity = dbContext.alphanumeric_tax_codes.Where(t => t.id == id).FirstOrDefault();
            dbContext.alphanumeric_tax_codes.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}