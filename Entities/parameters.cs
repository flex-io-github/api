using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class parameters
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public int tax_computation_id { get; set; }
        public int tax_basis_id { get; set; }
        public float weeks_in_year { get; set; }
        public float days_in_year { get; set; }
        public float hours_in_day { get; set; }
        public float union_dues { get; set; }
        public bool? is_paid_sh { get; set; }
        public bool? is_paid_lh { get; set; }
        public float nd_premium { get; set; }
        public bool? is_nd_premium_apply_to_all { get; set; }
        public int _13th_month_type_id { get; set; }
        public float _13th_month_round_factor { get; set; }
        public int _13th_month_round_direction_id { get; set; }
        public bool? is_13th_month_ignore_absences { get; set; }
        public bool? is_show_all_rates { get; set; }
        public bool? is_major_deductions_based_on_salary { get; set; }
        public bool? is_ignore_absences { get; set; }
        public int company_id { get; set; }
        public float days_in_week { get; set; }
        public float min_net_pay_for_loan { get; set; }
        public int min_net_pay_for_loan_type_id { get; set; }
        public bool? is_lh_required_day_before { get; set; }
        public bool? is_lh_required_day_after { get; set; }
        public bool? is_lh_allow_paid_leave_day_before { get; set; }
        public bool? is_lh_allow_unpaid_leave_day_before { get; set; }
        public bool? is_sh_required_day_before { get; set; }
        public bool? is_sh_required_day_after { get; set; }
        public bool? is_sh_allow_paid_leave_day_before { get; set; }
        public bool? is_sh_allow_unpaid_leave_day_before { get; set; }
        public bool? is_paid_sh2 { get; set; }
        public bool? is_sh2_required_day_before { get; set; }
        public bool? is_sh2_required_day_after { get; set; }
        public bool? is_sh2_allow_paid_leave_day_before { get; set; }
        public bool? is_sh2_allow_unpaid_leave_day_before { get; set; }
        public bool? is_lh_with_extra_pay { get; set; }
        public bool? is_sh_with_extra_pay { get; set; }
        public bool? is_sh2_with_extra_pay { get; set; }
        public bool? is_holiday_on_same_day_with_extra_pay { get; set; }
        public bool? is_lr_with_extra_pay { get; set; }
        public bool? is_sr_with_extra_pay { get; set; }
        public bool? is_s2r_with_extra_pay { get; set; }
        public float lh_extra_pay_percent { get; set; }
        public float sh_extra_pay_percent { get; set; }
        public float sh2_extra_pay_percent { get; set; }
        public float holiday_on_same_day_extra_pay_percent { get; set; }
        public float lr_extra_pay_percent { get; set; }
        public float sr_extra_pay_percent { get; set; }
        public float s2r_extra_pay_percent { get; set; }
        public int payment_type_id { get; set; }
        public float fb_tax_rate { get; set; }
        public int max_allowed_tardy_per_period { get; set; }
        public bool? is_deduct_prev_13th_month_pay { get; set; }
        public int leave_accrual_date_basis_id { get; set; }
        public bool? is_ignore_tardy { get; set; }
        public bool? is_ignore_midbreak { get; set; }
        public bool? is_ignore_undertime { get; set; }
        public bool? is_13th_month_ignore_tardy { get; set; }
        public bool? is_13th_month_ignore_midbreak { get; set; }
        public bool? is_13th_month_ignore_undertime { get; set; }
        public bool? is_compute_13th_month_projection { get; set; }
        public bool? is_ot_needs_approval { get; set; }
        public bool? is_exclude_no_time_summary { get; set; }
        public bool? is_exclude_no_timesheet { get; set; }
        public bool? is_compute_salary_adjustment { get; set; }
        public bool? is_reserve_tax_free_bonus { get; set; }
        public int normalize_tax_refund_pay_month { get; set; }
        public int normalize_tax_refund_payroll_period_id { get; set; }
        public bool? is_reserve_non_taxable_to_projected_13th_month_pay { get; set; }
        public int taxable_fringe_benefit_pay_element_id { get; set; }
        public int taxable_income_pay_element_id { get; set; }
        public int gross_up_per_payroll_to_pay_element_id { get; set; }
        public bool? is_compute_gross_up_per_payroll { get; set; }
        public bool? is_hours_required_based_on_cut_off { get; set; }
        public float cut_off_required_hours { get; set; }
        public bool? is_compute_ndot { get; set; }
        public bool? is_compute_non_regular_day_pay { get; set; }
        public bool? is_allow_rd_offset { get; set; }
        public bool? is_allow_rh_offset { get; set; }
        public bool? is_allow_sh_offset { get; set; }
        public bool? is_allow_sh2_offset { get; set; }
        public int new_hire_computation_basis_id { get; set; }
        public int min_take_home_pay_basis_id { get; set; }
        public bool? is_load_to_next_payroll { get; set; }
        public bool? is_compute_sss_based_on_salary { get; set; }
        public bool? is_compute_phic_based_on_salary { get; set; }
        public bool? is_compute_hdmf_based_on_salary { get; set; }
        public bool? is_consider_not_yet_hired_resigned_on_paid_rh { get; set; }
        public bool? is_consider_not_yet_hired_resigned_on_paid_sh { get; set; }
        public bool? is_consider_not_yet_hired_resigned_on_paid_sh2 { get; set; }
        public int ot_excess_rate_required_hours_after_shift { get; set; }
        public bool? make_absent_equal_to_reg_basic_if_exceed_on_time_summary { get; set; }
        public bool? make_absent_equal_to_reg_basic_if_exceed_on_timesheet { get; set; }
        public float tax_free_bonus { get; set; }
        public bool? is_active { get; set; }
        public int created_by_id { get; set; }
        public DateTime date_created { get; set; }
        public int modified_by_id { get; set; }
        public DateTime date_modified { get; set; }
    }
}
