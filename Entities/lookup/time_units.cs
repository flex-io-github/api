using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class time_units
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public string name { get; set; }
        public bool? is_active { get; set; }
        public bool? is_include_basic { get; set; }
        public bool? is_include_ot { get; set; }
        public bool? is_include_nd { get; set; }
        public bool? is_include_ndot { get; set; }
        public bool? is_minimum { get; set; }
        public bool? is_exclude_leave { get; set; }
        public bool? is_exclude_ob { get; set; }
        public bool? is_deduct_absent { get; set; }
        public bool? is_deduct_tardy { get; set; }
        public bool? is_deduct_mid_break { get; set; }
        public bool? is_deduct_undertime { get; set; }
        public bool? is_deduct_unpaid_holiday { get; set; }
        public bool? is_deduct_halfday { get; set; }
        public bool? is_prorated { get; set; }
        public bool? is_regular_day { get; set; }
        public bool? is_rest_day { get; set; }
        public bool? is_rest_day2 { get; set; }
        public bool? is_rest_day3 { get; set; }
        public bool? is_legal_holiday { get; set; }
        public bool? is_legal_rest_day { get; set; }
        public bool? is_legal_rest_day2 { get; set; }
        public bool? is_legal_rest_day3 { get; set; }
        public bool? is_special_holiday { get; set; }
        public bool? is_special_rest_day { get; set; }
        public bool? is_special_rest_day2 { get; set; }
        public bool? is_special_rest_day3 { get; set; }
        public bool? is_special_holiday2 { get; set; }
        public bool? is_special2_rest_day { get; set; }
        public bool? is_special2_rest_day2 { get; set; }
        public bool? is_special2_rest_day3 { get; set; }
        public bool? is_use_formula { get; set; }
        public bool? is_de_minimis { get; set; }
        public bool? is_include_tardy { get; set; }
        public bool? is_include_midbreak { get; set; }
        public bool? is_include_undertime { get; set; }
        public bool? is_deduct_leave_hours { get; set; }
    }
}
