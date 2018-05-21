using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id{ get; set; }
		
        public int company_id { get; set; }

        //[Required]
        public string employee_code { get; set; }

        //[Required]
        public string first_name { get; set; }

        public string middle_name { get; set; }

        //[Required]
        public string last_name { get; set; }

        public string prefix { get; set; }

        public int suffix_id { get; set; }

        public string tfn { get; set; }

        //[Phone]
        public string mobile_number { get; set; }

        //[EmailAddress]
        public string email_address { get; set; }
       
        public DateTime date_of_birth { get; set; }

        public int gender_id { get; set; }

        public int work_type_id { get; set; }

        public int employee_status_id { get; set; }

        public int bank_id { get; set; }

        public string tin { get; set; }
		
		public string hdmf_id { get; set; }
		
		public string pag_ibig_number { get; set; }
		
		public string sss_number { get; set; }
		
		public string phic_number { get; set; }

        public int telephone_number { get; set; }

        public int rdo_id { get; set; }

        public int position_id { get; set; }
		
        public int alphanumeric_tax_code_id { get; set; }
		
        public int civil_status_id { get; set; }
		
        public int employee_spouse_id { get; set; }
		
		public string nickname { get; set; }
		
		public string place_of_birth { get; set; }
		
		public string mothers_maiden_name { get; set; }
		
		public string fathers_name { get; set; }
		
		public int citizenship_id { get; set; }
		
		public string fax_number { get; set; }
		
		public int employment_type_id { get; set; }
		
		public int department_id { get; set; }
		
		public int cost_center_id { get; set; }
		
		public int location_id { get; set; }
		
		public int supervisor_id { get; set; }
		
		public bool? is_active { get; set; }
		
		public bool? is_union { get; set; }
		
		public int pay_group_id { get; set; }
		
		public int payment_type_id { get; set; }
		
		public int payroll_frequency_id { get; set; }

        public int parameter_id { get; set; }

        public DateTime date_effective { get; set; }

        public int time_source_id { get; set; }

        public float? monthly_rate { get; set; }
        public float? monthly_cola { get; set; }
        public float? monthly_allowance { get; set; }
        public float? daily_rate { get; set; }
        public float? daily_cola { get; set; }
        public float? daily_allowance { get; set; }
        public float? hourly_rate { get; set; }
        public float? hourly_cola { get; set; }
        public float? hourly_allowance { get; set; }
        public DateTime? date_hired { get; set; }
        public DateTime? date_regular { get; set; }
        public DateTime? date_separated { get; set; }
        public DateTime? contract_start_date { get; set; }
        public DateTime? contract_end_date { get; set; }
        public int? payout_type_id { get; set; }
        
        //[Required]
        public int created_by_id { get; set; }

        //[Required]
        public DateTime date_created { get; set; }

        public int modified_by_id { get; set; }

        public DateTime date_modified { get; set; }
    }
}