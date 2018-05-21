using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class philhealth
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int bracket { get; set; }
        public float range1 { get; set; }
        public float range2 { get; set; }
        public float phic_ee { get; set; }
        public float phic_er { get; set; }
        public float salary_base { get; set; }
        public float total { get; set; }
    }
}