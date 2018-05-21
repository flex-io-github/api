using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class bank_accounts
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id{ get; set; }	
        public string name { get; set; }
        public int? bank_id { get; set; }
        public string bank_code { get; set; }
        public string branch_code { get; set; }
        public string account_number { get; set; }
        public string address { get; set; }
        public string contact_person { get; set; }
        public int? currency_id { get; set; }
        public int? company_id { get; set; }
        public string account_title { get; set; }
        public string account_code { get; set; }
        public string contact_person_pos { get; set; }
        public float? ceiling_amount { get; set; }
        public string branch_name { get; set; }
        public bool? is_use_account_number_dep_branch_code { get; set; }
        public string bank_company_id { get; set; }
        public string bank_company_eft_key { get; set; }
        public string transaction_type { get; set; }
        public string alternate_transaction_type { get; set; }
        public string receiving_bank_name { get; set; }
        public string receiving_bank_id_sort_code { get; set; }
        public string receiving_bank_city_name { get; set; }
        public bool? is_include_header { get; set; }
        public bool? is_include_trailer { get; set; }
        public int? created_by_id { get; set; }
        public DateTime? date_created { get; set; }
        public int? modified_by_id { get; set; }
        public DateTime? date_modified { get; set; }
    }
}