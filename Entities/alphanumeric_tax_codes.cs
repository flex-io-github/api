using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class alphanumeric_tax_codes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string display { get; set; }

        public string name { get; set; }
		
		public float rate { get; set; }
		
		public bool is_ewt { get; set; }
		
		public bool is_fb_tax { get; set; }
		
		public bool is_final_tax { get; set; }

        public bool is_active { get; set; }
		
        public int created_by_id { get; set; }
		
        public DateTime date_created { get; set; }
		
        public int modified_by_id { get; set; }
		
        public DateTime date_modified { get; set; }
    }
}
