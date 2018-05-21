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
    public class SSSController : Controller
    {
        Entities.DataContext dbContext;

        public SSSController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        [HttpGet]
        public IEnumerable<sss> Get()
        {
            return dbContext.sss.OrderBy(x => x.bracket).ToList();

        }
    }
}
