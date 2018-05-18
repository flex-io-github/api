using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class de_minimis
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public string display { get; set; }
		public string name { get; set; }
        public float? ceiling { get; set; }
        public int? de_minimis_unit_id {get; set; }
        public int? time_unit_id { get; set; }
        public string description { get; set; }
        public string remarks { get; set; }
        public int? pay_tax_type_id { get; set; }
		public bool? is_active { get; set; }
		public int? created_by_id { get; set; }
		public DateTime? date_created { get; set; }
		public int? modified_by_id { get; set; }
		public DateTime? date_modified { get; set; }
    }
}
