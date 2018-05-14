using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class employee_spouse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public int employee_id { get; set; }
		public string first_name { get; set; }
		public string middle_name { get; set; }
		public string last_name { get; set; }
		public string tin { get; set; }
		public DateTime date_of_birth { get; set; }
		public string contact_number { get; set; }
		public string email_address { get; set; }
		public bool? is_claiming_exemptions { get; set; }
		public string employer_name { get; set; }
		public string employer_tin { get; set; }
		public int employment_status_id { get; set; }
		public int company_id { get; set; }
		public string employer_tin_branch { get; set; }
		public int created_by_id { get; set; }
		public DateTime date_created { get; set; }
		public int modified_by_id { get; set; }
		public DateTime date_modified { get; set; }
    }
}
