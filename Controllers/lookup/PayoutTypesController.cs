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
    public class PayoutTypesController : Controller
    {
        Entities.DataContext dbContext;

        public PayoutTypesController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.payout_types
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }
    }
}