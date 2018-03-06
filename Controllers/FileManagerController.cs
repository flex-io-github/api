using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Enums;
using WebApi.Interfaces;

namespace WebApi
{
    [Route("[controller]")]
    public class FileManagerController : Controller
    {
        Entities.DataContext dbContext;

        public FileManagerController(Entities.DataContext dbContext) => this.dbContext = dbContext;

        [HttpGet]
        public IEnumerable<file_manager> Get()
        {
            return dbContext.file_manager.ToList();
        }

        // POST api/values
        [HttpPost]
        public file_manager Post([FromBody]file_manager value)
        {
            dbContext.file_manager.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public file_manager Delete(int id)
        {
            var entity = dbContext.file_manager.Where(t => t.id == id).FirstOrDefault();
            dbContext.file_manager.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}