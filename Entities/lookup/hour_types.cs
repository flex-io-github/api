using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class hour_types
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public string display { get; set; }
		public string name { get; set; }
		public string sys_code { get; set; }
		public bool? is_core_time { get; set; }
		public bool? is_overtime { get; set; }
		public bool? is_break_time { get; set; }
		public bool? is_nd { get; set; }
		public int? order { get; set; }
    }
}
