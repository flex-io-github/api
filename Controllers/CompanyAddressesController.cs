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
    public class CompanyAddressesController : Controller
    {
        Entities.DataContext dbContext;
        public CompanyAddressesController(Entities.DataContext dbContext) => this.dbContext = dbContext;

        //GET: api/company_addresses
       [HttpGet]
        public IEnumerable<company_addresses> Get()
        {
            return dbContext.company_addresses.ToList();

        }

        // GET: api/company_addresses/5
        [HttpGet("{id}")]
        public company_addresses Get(int id)
        {
            return dbContext.company_addresses.Where(t => t.id == id).FirstOrDefault();
        }

        // POST: api/company_addresses
        [HttpPost]
        public company_addresses Post([FromBody]company_addresses value)
        {
            dbContext.company_addresses.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // PUT: api/company_addresses/5
        [HttpPut("{id}")]
        public company_addresses Put(int id, [FromBody]company_addresses value)
        {
            var entity = dbContext.company_addresses.Where(t => t.id == id).FirstOrDefault();
			entity.unit_room_number_floor = value.unit_room_number_floor;
			entity.building_name = value.building_name;
			entity.lot_block_phase_house_number = value.lot_block_phase_house_number;
			entity.street_name = value.street_name;
			entity.village_subdivision = value.village_subdivision;
			entity.barangay = value.barangay;
			entity.town_district = value.town_district;
			entity.municipality_id = value.municipality_id;
			entity.city_province = value.city_province;
			entity.address_type_id = value.address_type_id;
            dbContext.SaveChanges();
            return entity;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public company_addresses Delete(int id)
        {
            var entity = dbContext.company_addresses.Where(t => t.id == id).FirstOrDefault();
            dbContext.company_addresses.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}