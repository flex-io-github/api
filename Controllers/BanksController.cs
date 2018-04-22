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
    public class BanksController : Controller
    {
        Entities.DataContext dbContext;
        public BanksController(Entities.DataContext dbContext) => this.dbContext = dbContext;

        //GET: api/banks
       [HttpGet]
        public IEnumerable<banks> Get()
        {
            return dbContext.banks.ToList();

        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.banks.Where(x => x.active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/banks/5
        [HttpGet("{id}")]
        public banks Get(int id)
        {
            return dbContext.banks.Where(t => t.id == id).FirstOrDefault();
        }

        // POST: api/banks
        [HttpPost]
        public banks Post([FromBody]banks value)
        {
            dbContext.banks.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // PUT: api/banks/5
        [HttpPut("{id}")]
        public banks Put(int id, [FromBody]banks value)
        {
            var entity = dbContext.banks.Where(t => t.id == id).FirstOrDefault();
            entity.display = value.display;
            entity.name = value.name;
            entity.active = value.active;
            dbContext.SaveChanges();
            return entity;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public banks Delete(int id)
        {
            var entity = dbContext.banks.Where(t => t.id == id).FirstOrDefault();
            dbContext.banks.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}