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
    public class ParametersController : Controller
    {
        Entities.DataContext dbContext;

        public ParametersController(Entities.DataContext dbContext) => this.dbContext = dbContext;
        
        // GET: api/parameters
        [HttpGet]
        public IEnumerable<parameters> Get()
        {
            return dbContext.parameters.ToList();
        }

        [HttpGet("LookUp")]
        public dynamic GetLookup()
        {
            return dbContext.parameters.Where(x => x.is_active == true)
              .Select(x => new
              {
                  key = x.id,
                  text = x.name,
              }).ToList();
        }

        // GET: api/parameters/5
        [HttpGet("{id}")]
        public parameters Get(int id)
        {
            return dbContext.parameters.Where(t => t.id == id).FirstOrDefault();
        }
        
        // POST: api/parameters
        [HttpPost]
        public parameters Post([FromBody]parameters value)
        {
            dbContext.parameters.Add(value);
            dbContext.SaveChanges();
            return value;
        }
        
        // PUT: api/parameters/5
        [HttpPut("{id}")]
        public parameters Put(int id, [FromBody]parameters value)
        {
            var entity = dbContext.parameters.Where(t => t.id == id).FirstOrDefault();
            entity.name = value.name;
            entity.tax_computation_id = value.tax_computation_id;
            entity.tax_basis_id = value.tax_basis_id;
            entity.weeks_in_year = value.weeks_in_year;
            entity.days_in_year = value.days_in_year;
            entity.hours_in_day = value.hours_in_day;
            entity.union_dues = value.union_dues;
            entity.is_paid_sh = value.is_paid_sh;
            entity.is_paid_lh = value.is_paid_lh;
            entity.nd_premium = value.nd_premium;
            entity.is_nd_premium_apply_to_all = value.is_nd_premium_apply_to_all;
            entity._13th_month_type_id = value._13th_month_type_id;
            entity._13th_month_round_factor = value._13th_month_round_factor;
            entity._13th_month_round_direction_id = value._13th_month_round_direction_id;
            entity.is_13th_month_ignore_absences = value.is_13th_month_ignore_absences;
            entity.is_show_all_rates = value.is_show_all_rates;
            entity.is_major_deductions_based_on_salary = value.is_major_deductions_based_on_salary;
            entity.is_ignore_absences = value.is_ignore_absences;
            entity.company_id = value.company_id;
            entity.days_in_week = value.days_in_week;
            entity.min_net_pay_for_loan = value.min_net_pay_for_loan;
            entity.min_net_pay_for_loan_type_id = value.min_net_pay_for_loan_type_id;
            entity.is_lh_required_day_before = value.is_lh_required_day_before;
            entity.is_lh_required_day_after = value.is_lh_required_day_after;
            entity.is_lh_allow_paid_leave_day_before = value.is_lh_allow_paid_leave_day_before;
            entity.is_lh_allow_unpaid_leave_day_before = value.is_lh_allow_unpaid_leave_day_before;
            entity.is_sh_required_day_before = value.is_sh_required_day_before;
            entity.is_sh_required_day_after = value.is_sh_required_day_after;
            entity.is_sh_allow_paid_leave_day_before = value.is_sh_allow_paid_leave_day_before;
            entity.is_sh_allow_unpaid_leave_day_before = value.is_sh_allow_unpaid_leave_day_before;
            entity.is_paid_sh2 = value.is_paid_sh2;
            entity.is_sh2_required_day_before = value.is_sh2_required_day_before;
            entity.is_sh2_required_day_after = value.is_sh2_required_day_after;
            entity.is_sh2_allow_paid_leave_day_before = value.is_sh2_allow_paid_leave_day_before;
            entity.is_sh2_allow_unpaid_leave_day_before = value.is_sh2_allow_unpaid_leave_day_before;
            entity.is_lh_with_extra_pay = value.is_lh_with_extra_pay;
            entity.is_sh_with_extra_pay = value.is_sh_with_extra_pay;
            entity.is_sh2_with_extra_pay = value.is_sh2_with_extra_pay;
            entity.is_holiday_on_same_day_with_extra_pay = value.is_holiday_on_same_day_with_extra_pay;
            entity.is_lr_with_extra_pay = value.is_lr_with_extra_pay;
            entity.is_sr_with_extra_pay = value.is_sr_with_extra_pay;
            entity.is_s2r_with_extra_pay = value.is_s2r_with_extra_pay;
            entity.lh_extra_pay_percent = value.lh_extra_pay_percent;
            entity.sh_extra_pay_percent = value.sh_extra_pay_percent;
            entity.sh2_extra_pay_percent = value.sh2_extra_pay_percent;
            entity.holiday_on_same_day_extra_pay_percent = value.holiday_on_same_day_extra_pay_percent;
            entity.lr_extra_pay_percent = value.lr_extra_pay_percent;
            entity.sr_extra_pay_percent = value.sr_extra_pay_percent;
            entity.s2r_extra_pay_percent = value.s2r_extra_pay_percent;
            entity.payment_type_id = value.payment_type_id;
            entity.fb_tax_rate = value.fb_tax_rate;
            entity.max_allowed_tardy_per_period = value.max_allowed_tardy_per_period;
            entity.is_deduct_prev_13th_month_pay = value.is_deduct_prev_13th_month_pay;
            entity.leave_accrual_date_basis_id = value.leave_accrual_date_basis_id;
            entity.is_ignore_tardy = value.is_ignore_tardy;
            entity.is_ignore_midbreak = value.is_ignore_midbreak;
            entity.is_ignore_undertime = value.is_ignore_undertime;
            entity.is_13th_month_ignore_tardy = value.is_13th_month_ignore_tardy;
            entity.is_13th_month_ignore_midbreak = value.is_13th_month_ignore_midbreak;
            entity.is_13th_month_ignore_undertime = value.is_13th_month_ignore_undertime;
            entity.is_compute_13th_month_projection = value.is_compute_13th_month_projection;
            entity.is_ot_needs_approval = value.is_ot_needs_approval;
            entity.is_exclude_no_time_summary = value.is_exclude_no_time_summary;
            entity.is_exclude_no_timesheet = value.is_exclude_no_timesheet;
            entity.is_compute_salary_adjustment = value.is_compute_salary_adjustment;
            entity.is_reserve_tax_free_bonus = value.is_reserve_tax_free_bonus;
            entity.normalize_tax_refund_pay_month = value.normalize_tax_refund_pay_month;
            entity.normalize_tax_refund_payroll_period_id = value.normalize_tax_refund_payroll_period_id;
            entity.is_reserve_non_taxable_to_projected_13th_month_pay = value.is_reserve_non_taxable_to_projected_13th_month_pay;
            entity.taxable_fringe_benefit_pay_element_id = value.taxable_fringe_benefit_pay_element_id;
            entity.taxable_income_pay_element_id = value.taxable_income_pay_element_id;
            entity.gross_up_per_payroll_to_pay_element_id = value.gross_up_per_payroll_to_pay_element_id;
            entity.is_compute_gross_up_per_payroll = value.is_compute_gross_up_per_payroll;
            entity.is_hours_required_based_on_cut_off = value.is_hours_required_based_on_cut_off;
            entity.cut_off_required_hours = value.cut_off_required_hours;
            entity.is_compute_ndot = value.is_compute_ndot;
            entity.is_compute_non_regular_day_pay = value.is_compute_non_regular_day_pay;
            entity.is_allow_rd_offset = value.is_allow_rd_offset;
            entity.is_allow_rh_offset = value.is_allow_rh_offset;
            entity.is_allow_sh_offset = value.is_allow_sh_offset;
            entity.is_allow_sh2_offset = value.is_allow_sh2_offset;
            entity.new_hire_computation_basis_id = value.new_hire_computation_basis_id;
            entity.min_take_home_pay_basis_id = value.min_take_home_pay_basis_id;
            entity.is_load_to_next_payroll = value.is_load_to_next_payroll;
            entity.is_compute_sss_based_on_salary = value.is_compute_sss_based_on_salary;
            entity.is_compute_phic_based_on_salary = value.is_compute_phic_based_on_salary;
            entity.is_compute_hdmf_based_on_salary = value.is_compute_hdmf_based_on_salary;
            entity.is_consider_not_yet_hired_resigned_on_paid_rh = value.is_consider_not_yet_hired_resigned_on_paid_rh;
            entity.is_consider_not_yet_hired_resigned_on_paid_sh = value.is_consider_not_yet_hired_resigned_on_paid_sh;
            entity.is_consider_not_yet_hired_resigned_on_paid_sh2 = value.is_consider_not_yet_hired_resigned_on_paid_sh2;
            entity.ot_excess_rate_required_hours_after_shift = value.ot_excess_rate_required_hours_after_shift;
            entity.make_absent_equal_to_reg_basic_if_exceed_on_time_summary = value.make_absent_equal_to_reg_basic_if_exceed_on_time_summary;
            entity.make_absent_equal_to_reg_basic_if_exceed_on_timesheet = value.make_absent_equal_to_reg_basic_if_exceed_on_timesheet;
            entity.tax_free_bonus = value.tax_free_bonus;
			entity.is_active = value.is_active;
			dbContext.SaveChanges();
            return entity;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public parameters Delete(int id)
        {
            var entity = dbContext.parameters.Where(t => t.id == id).FirstOrDefault();
            dbContext.parameters.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
