using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class employment_types
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public string display { get; set; }
		public string name { get; set; }
		public bool? is_active { get; set; }
		public bool? is_process { get; set; }
		public bool? is_temporary { get; set; }
		public bool? is_probation { get; set; }
		public bool? is_contractual { get; set; }
		public bool? is_project_based { get; set; }
		public bool? is_outsourced { get; set; }
		public bool? is_absorbed { get; set; }
		public bool? is_regular { get; set; }
		public bool? is_resigned { get; set; }
		public bool? is_terminated { get; set; }
		public bool? is_retired { get; set; }
		public int created_by_id { get; set; }
		public DateTime date_created { get; set; }
		public int modified_by_id { get; set; }
		public DateTime date_modified { get; set; }
    }
}
