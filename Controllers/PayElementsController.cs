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
    public class PayElementsController : Controller
    {
        Entities.DataContext dbContext;

        public PayElementsController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/pay_elements
        [HttpGet]
        public IEnumerable<pay_elements> Get()
        {
            return dbContext.pay_elements.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.pay_elements.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/pay_elements/5
        [HttpGet("{id}")]
        public pay_elements Get(int id)
        {
            return dbContext.pay_elements.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/pay_elements
        [HttpPost]
        public pay_elements Post([FromBody]pay_elements value)
        {
            dbContext.pay_elements.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/pay_elements/5
        [HttpPut("{id}")]
        public pay_elements Put(int id, [FromBody]pay_elements value)
        {
            var entity = dbContext.pay_elements.Where(t => t.id == id).FirstOrDefault();
            entity.account_code = value.account_code;
            entity.account_title = value.account_title;
            entity.is_active = value.is_active;
            entity.display = value.display;
            entity.company_id = value.company_id;
            entity.constant_value = value.constant_value;
            entity.currency_id = value.currency_id;
            entity.day_type_id = value.day_type_id;
            entity.is_deduct_absences = value.is_deduct_absences;
            entity.is_deduct_midbreak = value.is_deduct_midbreak;
            entity.is_deduct_tardy = value.is_deduct_tardy;
            entity.is_deduct_undertime = value.is_deduct_undertime;
            entity.de_minimis_id = value.de_minimis_id;
            entity.display_order = value.display_order;
            entity.divisor = value.divisor;
            entity.is_exclude_leave = value.is_exclude_leave;
            entity.is_exclude_ob = value.is_exclude_ob;
            entity.expanded_tax_rate = value.expanded_tax_rate;
            entity.fb_taxable_rate = value.fb_taxable_rate;
            entity.is_formula_for_all_employees = value.is_formula_for_all_employees;
            entity.group_code = value.group_code;
            entity.hdmf_loan_diskette_code = value.hdmf_loan_diskette_code;
            entity.hdmf_loan_excel_code = value.hdmf_loan_excel_code;
            entity.hdmf_loan_printout_code = value.hdmf_loan_printout_code;
            entity.hour_type_id = value.hour_type_id;
            entity.is_ignore_attendance = value.is_ignore_attendance;
            entity.is_include_basic = value.is_include_basic;
            entity.is_include_13th_month = value.is_include_13th_month;
            entity.is_include_in_hdmf = value.is_include_in_hdmf;
            entity.is_include_in_net_pay = value.is_include_in_net_pay;
            entity.is_include_in_phic = value.is_include_in_phic;
            entity.is_include_in_sss = value.is_include_in_sss;
            entity.is_include_nd = value.is_include_nd;
            entity.is_include_ndot = value.is_include_ndot;
            entity.is_include_ot = value.is_include_ot;
            entity.interest_pay_element_id = value.interest_pay_element_id;
            entity.interest_rate = value.interest_rate;
            entity.interest_rate_type_id = value.interest_rate_type_id;
            entity.interest_type_id = value.interest_type_id;
            entity.is_13th_month_pay = value.is_13th_month_pay;
            entity.is_absent = value.is_absent;
            entity.is_absent_al = value.is_absent_al;
            entity.is_allowance = value.is_allowance;
            entity.is_cap_excess_credit_to_next_payroll = value.is_cap_excess_credit_to_next_payroll;
            entity.is_company_loan = value.is_company_loan;
            entity.is_compute_capping_for_loan = value.is_compute_capping_for_loan;
            entity.is_compute_formula_after_net_pay = value.is_compute_formula_after_net_pay;
            entity.is_deduct_halfday = value.is_deduct_halfday;
            entity.is_deduct_leave_hours = value.is_deduct_leave_hours;
            entity.is_deduct_unpaid_holiday = value.is_deduct_unpaid_holiday;
            entity.is_de_minimis_benefits = value.is_de_minimis_benefits;
            entity.is_display_zero_value = value.is_display_zero_value;
            entity.is_earning = value.is_earning;
            entity.is_ew_tax = value.is_ew_tax;
            entity.is_ew_taxable = value.is_ew_taxable;
            entity.is_fb_tax = value.is_fb_tax;
            entity.is_fb_taxable = value.is_fb_taxable;
            entity.is_final_tax = value.is_final_tax;
            entity.is_gross_up = value.is_gross_up;
            entity.is_hdmf = value.is_hdmf;
            entity.is_include_midbreak = value.is_include_midbreak;
            entity.is_include_tardy = value.is_include_tardy;
            entity.is_include_undertime = value.is_include_undertime;
            entity.is_loan = value.is_loan;
            entity.is_major_deduction = value.is_major_deduction;
            entity.is_midbreak = value.is_midbreak;
            entity.is_midbreak_al = value.is_midbreak_al;
            entity.is_minimum = value.is_minimum;
            entity.is_nd = value.is_nd;
            entity.is_non_taxable_contributions = value.is_non_taxable_contributions;
            entity.is_non_taxable_salaries = value.is_non_taxable_salaries;
            entity.is_overtime = value.is_overtime;
            entity.is_phic = value.is_phic;
            entity.is_premium_paid = value.is_premium_paid;
            entity.is_prorated = value.is_prorated;
            entity.is_reg_basic = value.is_reg_basic;
            entity.is_reg_basic_al = value.is_reg_basic_al;
            entity.is_reimbursement = value.is_reimbursement;
            entity.is_show_on_schedule_element_updates = value.is_show_on_schedule_element_updates;
            entity.is_sss = value.is_sss;
            entity.is_sss_ec = value.is_sss_ec;
            entity.is_tardy = value.is_tardy;
            entity.is_tardy_al = value.is_tardy_al;
            entity.is_taxable = value.is_taxable;
            entity.is_taxable_basic_salary = value.is_taxable_basic_salary;
            entity.is_taxable_commission = value.is_taxable_commission;
            entity.is_taxable_ecola = value.is_taxable_ecola;
            entity.is_taxable_fees = value.is_taxable_fees;
            entity.is_taxable_fixed_housing_allowance = value.is_taxable_fixed_housing_allowance;
            entity.is_taxable_hazard_pay = value.is_taxable_hazard_pay;
            entity.is_taxable_holiday_pay = value.is_taxable_holiday_pay;
            entity.is_taxable_night_shift_differential = value.is_taxable_night_shift_differential;
            entity.is_taxable_other_regular1 = value.is_taxable_other_regular1;
            entity.is_taxable_other_regular2 = value.is_taxable_other_regular2;
            entity.is_taxable_other_supplementary1 = value.is_taxable_other_supplementary1;
            entity.is_taxable_other_supplementary2 = value.is_taxable_other_supplementary2;
            entity.is_taxable_overtime_pay = value.is_taxable_overtime_pay;
            entity.is_taxable_profit_sharing = value.is_taxable_profit_sharing;
            entity.is_taxable_representation = value.is_taxable_representation;
            entity.is_taxable_transportation = value.is_taxable_transportation;
            entity.is_tax_paid_by_employer = value.is_tax_paid_by_employer;
            entity.is_undertime = value.is_undertime;
            entity.is_undertime_al = value.is_undertime_al;
            entity.is_union = value.is_union;
            entity.is_wtax = value.is_wtax;
            entity.loan_capping_amount_type_id = value.loan_capping_amount_type_id;
            entity.loan_capping_value = value.loan_capping_value;
            entity.minimum_qty = value.minimum_qty;
            entity.mult = value.mult;
            entity.name = value.name;
            entity.no_of_payments = value.no_of_payments;
            entity.parent_pay_element_id = value.parent_pay_element_id;
            entity.payable_account_code = value.payable_account_code;
            entity.pay_code = value.pay_code;
            entity.pay_element_display_id = value.pay_element_display_id;
            entity.pay_element_payroll_register_display_id = value.pay_element_payroll_register_display_id;
            entity.pay_element_type_id = value.pay_element_type_id;
            entity.pay_reg_code = value.pay_reg_code;
            entity.payroll_hour_type_id = value.payroll_hour_type_id;
            entity.payroll_register_group_code = value.payroll_register_group_code;
            entity.pay_tax_type_id = value.pay_tax_type_id;
            entity.period_pay_element_id = value.period_pay_element_id;
            entity.priority_level = value.priority_level;
            entity.prorated_date_basis_id = value.prorated_date_basis_id;
            entity.rate_id = value.rate_id;
            entity.sys_code = value.sys_code;
            entity.taxable_mult = value.taxable_mult;
            entity.time_type_id = value.time_type_id;
            entity.time_unit_id = value.time_unit_id;
            entity.is_use_formula = value.is_use_formula;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public pay_elements Delete(int id)
        {
            var entity = dbContext.pay_elements.Where(t => t.id == id).FirstOrDefault();
            dbContext.pay_elements.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
