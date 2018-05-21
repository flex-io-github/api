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
    public class PhilHealthController : Controller
    {
        Entities.DataContext dbContext;

        public PhilHealthController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        [HttpGet]
        public IEnumerable<philhealth> Get()
        {
            return dbContext.philhealth.OrderBy(x => x.bracket).ToList();

        }
    }
}
