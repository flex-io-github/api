using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class hdmf
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int bracket { get; set; }
        public float range1 { get; set; }
        public float range2 { get; set; }
        public float percent_ee { get; set; }
        public float percent_er { get; set; }
        public float min_ee { get; set; }
        public float min_er { get; set; }
        public float max_ee { get; set; }
        public float max_er { get; set; }
        public float non_taxable_amount { get; set; }
    }
}