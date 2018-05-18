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
    public class PayrollFrequenciesController : Controller
    {
        Entities.DataContext dbContext;

        public PayrollFrequenciesController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.payroll_frequencies
              .Select(x => new
              {
                  key = x.id,
                  text = x.display,
              }).ToList();
        }
    }
}
