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
    public class HDMFController : Controller
    {
        Entities.DataContext dbContext;

        public HDMFController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        [HttpGet]
        public IEnumerable<hdmf> Get()
        {
            return dbContext.hdmf.OrderBy(x => x.bracket).ToList();

        }
    }
}
