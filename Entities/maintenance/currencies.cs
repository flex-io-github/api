using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class currencies
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id{ get; set; }
		
        //[Required]
        public string display { get; set; }

        //[Required]
        public string name { get; set; }
		
        public bool? is_active { get; set; }

        //[Required]
        public int? created_by_id { get; set; }

        //[Required]
        public DateTime? date_created { get; set; }

        public int? modified_by_id { get; set; }

        public DateTime? date_modified { get; set; }
    }
}