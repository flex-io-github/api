using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class philhealth_ver2
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int bracket { get; set; }
        public float range1 { get; set; }
        public float range2 { get; set; }
        public int contribution_type_id { get; set; }
        public float phic_ee { get; set; }
        public float phic_er { get; set; }
    }
}