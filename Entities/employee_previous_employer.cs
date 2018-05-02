using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class employee_previous_employer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public int employee_id { get; set; }
		public string name { get; set; }
		public string address { get; set; }
		public string zip_code { get; set; }
		public string tin { get; set; }
		public int year { get; set; }
		public float _25_gross_taxable_compensation_income { get; set; }
		public float _27_premium_paid { get; set; }
		public float _31_total_tax_withheld { get; set; }
		public float _37_13th_month_pay_and_other_benefits { get; set; }
		public float _38_de_minimis_benefits { get; set; }
		public float _39_contributions_and_union_dues { get; set; }
		public float _40_salaries_and_compensation { get; set; }
		public float _51_taxable_13th_month_pay_and_other_benefits { get; set; }
		public int created_by_id { get; set; }
		public DateTime date_created { get; set; }
		public int modified_by_id { get; set; }
		public DateTime date_modified { get; set; }
    }
}
