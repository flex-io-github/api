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
    public class BankAccountsController : Controller
    {
        Entities.DataContext dbContext;
        public BankAccountsController(Entities.DataContext dbContext) => this.dbContext = dbContext;

        //GET: api/bank_accounts
       [HttpGet]
        public IEnumerable<bank_accounts> Get()
        {
            return dbContext.bank_accounts.ToList();

        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.bank_accounts
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/bank_accounts/5
        [HttpGet("{id}")]
        public bank_accounts Get(int id)
        {
            return dbContext.bank_accounts.Where(t => t.id == id).FirstOrDefault();
        }

        // POST: api/bank_accounts
        [HttpPost]
        public bank_accounts Post([FromBody]bank_accounts value)
        {
            dbContext.bank_accounts.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // PUT: api/bank_accounts/5
        [HttpPut("{id}")]
        public bank_accounts Put(int id, [FromBody]bank_accounts value)
        {
            var entity = dbContext.bank_accounts.Where(t => t.id == id).FirstOrDefault();
            entity.name = value.name;
            entity.bank_id = value.bank_id;
            entity.bank_code = value.bank_code;
            entity.branch_code = value.branch_code;
            entity.account_number = value.account_number;
            entity.address = value.address;
            entity.contact_person = value.contact_person;
            entity.currency_id = value.currency_id;
            entity.company_id = value.company_id;
            entity.account_title = value.account_title;
            entity.account_code = value.account_code;
            entity.contact_person_pos = value.contact_person_pos;
            entity.ceiling_amount = value.ceiling_amount;
            entity.branch_name = value.branch_name;
            entity.is_use_account_number_dep_branch_code = value.is_use_account_number_dep_branch_code;
            entity.bank_company_id = value.bank_company_id;
            entity.bank_company_eft_key = value.bank_company_eft_key;
            entity.transaction_type = value.transaction_type;
            entity.alternate_transaction_type = value.alternate_transaction_type;
            entity.receiving_bank_name = value.receiving_bank_name;
            entity.receiving_bank_id_sort_code = value.receiving_bank_id_sort_code;
            entity.receiving_bank_city_name = value.receiving_bank_city_name;
            entity.is_include_header = value.is_include_header;
            entity.is_include_trailer = value.is_include_trailer;
            dbContext.SaveChanges();
            return entity;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bank_accounts Delete(int id)
        {
            var entity = dbContext.bank_accounts.Where(t => t.id == id).FirstOrDefault();
            dbContext.bank_accounts.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}