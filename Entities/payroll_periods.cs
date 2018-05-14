using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class payroll_periods
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public bool? is_active { get; set; }
        public int period_order { get; set; }
        public int company_id { get; set; }
        public int payroll_period_type_id { get; set; }
        public bool? is_regular_payroll_period { get; set; }
        public bool? is_13th_month_pay { get; set; }
        public bool? is_final_pay { get; set; }
        public bool? is_annualization { get; set; }
        public bool? is_special_payroll { get; set; }
        public int created_by_id { get; set; }
        public DateTime date_created { get; set; }
        public int modified_by_id { get; set; }
        public DateTime date_modified { get; set; }
    }
}
