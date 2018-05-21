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
    public class PhilHealthVer2Controller : Controller
    {
        Entities.DataContext dbContext;

        public PhilHealthVer2Controller(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        [HttpGet]
        public IEnumerable<philhealth_ver2> Get()
        {
            return dbContext.philhealth_ver2.OrderBy(x => x.bracket).ToList();

        }
    }
}
