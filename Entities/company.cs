using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id{ get; set; }
        public string display { get; set; }
        public string register_name { get; set; }
        public string telephone_number { get; set; }
        public string cellphone_number { get; set; }
        public string tin { get; set; }
        public string sss_number { get; set; }
        public string phic_number { get; set; }
        public string hdmf_number { get; set; }
        public int rdo_id { get; set; }
        public string line_of_business { get; set; }
        public int bank_id { get; set; }
        public bool? is_active { get; set; }
        public int created_by_id { get; set; }
        public DateTime date_created { get; set; }
        public int modified_by_id { get; set; }
        public DateTime date_modified { get; set; }
    }
}