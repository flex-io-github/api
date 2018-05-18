using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class pay_tax_types
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public string display { get; set; }
		public string name { get; set; }
		public bool? is_earning { get; set; }
		public bool? is_minimum_wage_earner_exempt { get; set; }
		public bool? is_taxable { get; set; }
		public int? taxable_mult { get; set; }
		public bool? is_supplementary { get; set; }
		public bool? is_13th_month_pay { get; set; }
    }
}
