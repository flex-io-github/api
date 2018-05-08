using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class departments
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public string display { get; set; }
		public string name { get; set; }
		public bool is_active { get; set; }
		public int created_by_id { get; set; }
		public DateTime date_created { get; set; }
		public int modified_by_id { get; set; }
		public DateTime date_modified { get; set; }
    }
}
