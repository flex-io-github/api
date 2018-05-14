using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class tax_codes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public string group { get; set; }
		public int sequence { get; set; }
		public string display { get; set; }
		public int dependents { get; set; }
		public float exemption { get; set; }
		public string description { get; set; }
		public string remarks { get; set; }
		public int year_end { get; set; }
		public bool? is_active { get; set; }
    }
}
