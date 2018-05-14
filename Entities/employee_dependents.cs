using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class employee_dependents
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public int company_id { get; set; }
		public int employee_id { get; set; }
		public string first_name { get; set; }
		public string middle_name { get; set; }
		public string last_name { get; set; }
		public DateTime date_of_birth { get; set; }
		public int relationship_id { get; set; }
		public bool? is_mentally_physically_incapacitated { get; set; }
		public bool? is_active { get; set; }
		public int created_by_id { get; set; }
		public DateTime date_created { get; set; }
		public int modified_by_id { get; set; }
		public DateTime date_modified { get; set; }
    }
}
