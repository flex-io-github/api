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
    public class EmployeeAddressesController : Controller
    {
        Entities.DataContext dbContext;
        public EmployeeAddressesController(Entities.DataContext dbContext) => this.dbContext = dbContext;

        //GET: api/employee_addresses
       [HttpGet]
        public IEnumerable<employee_addresses> Get()
        {
            return dbContext.employee_addresses.ToList();

        }

        // GET: api/employee_addresses/5
        [HttpGet("{id}")]
        public employee_addresses Get(int id)
        {
            return dbContext.employee_addresses.Where(t => t.id == id).FirstOrDefault();
        }

        // POST: api/employee_addresses
        [HttpPost]
        public employee_addresses Post([FromBody]employee_addresses value)
        {
            dbContext.employee_addresses.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // PUT: api/employee_addresses/5
        [HttpPut("{id}")]
        public employee_addresses Put(int id, [FromBody]employee_addresses value)
        {
            var entity = dbContext.employee_addresses.Where(t => t.id == id).FirstOrDefault();
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
        public employee_addresses Delete(int id)
        {
            var entity = dbContext.employee_addresses.Where(t => t.id == id).FirstOrDefault();
            dbContext.employee_addresses.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}