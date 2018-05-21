using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class sss
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int bracket { get; set; }
        public float range1 { get; set; }
        public float range2 { get; set; }
        public float monthly_salary_credit { get; set; }
        public float sss_ee { get; set; }
        public float sss_er { get; set; }
        public float ecc_er { get; set; }
        public float sss_total { get; set; }
    }
}