using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class payroll_frequencies
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public string display { get; set; }
		public int order { get; set; }
		public bool? is_include_in_payroll_cut_off_schedule { get; set; }
		public bool? is_include_in_payroll_cut_off_generate { get; set; }
    }
}
