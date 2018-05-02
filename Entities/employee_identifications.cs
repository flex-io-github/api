using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class employee_identifications
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public int employee_id { get; set; }
		public int identification_type_id { get; set; }
		public string number { get; set; }
		public DateTime effective_date { get; set; }
		public DateTime expiry_date { get; set; }
		public string issuer { get; set; }
		public string place_coutry_of_issue { get; set; }
		public bool is_active { get; set; }
		public int created_by_id { get; set; }
		public DateTime date_created { get; set; }
		public int modified_by_id { get; set; }
		public DateTime date_modified { get; set; }
    }
}
