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
    public class TaxCodesController : Controller
    {
        Entities.DataContext dbContext;

        public TaxCodesController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/tax_codes
        [HttpGet]
        public IEnumerable<tax_codes> Get()
        {
            return dbContext.tax_codes.ToList();
        }
    }
}
