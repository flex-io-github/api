using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class day_types
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id{ get; set; }
        public string display { get; set; }
        public string name { get; set; }
        public bool? is_rest_day { get; set; }
        public bool? is_holiday { get; set; }
        public int? holiday_type_id { get; set; }
        public bool? is_legal { get; set; }
        public bool? is_special { get; set; }
        public bool? is_special2 { get; set; }
        public bool? is_regular { get; set; }
    }
}