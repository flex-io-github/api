﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id{ get; set; }

        //[Required]
        public string employee_code { get; set; }

        //[Required]
        public string first_name { get; set; }

        public string middle_name { get; set; }

        //[Required]
        public string last_name { get; set; }

        public string prefix { get; set; }

        public string suffix { get; set; }

        public string tfn { get; set; }

        //[Phone]
        public string mobile_number { get; set; }

        //[EmailAddress]
        public string email_address { get; set; }
       
        public DateTime date_of_birth { get; set; }

        public int gender_id { get; set; }

        public int work_type_id { get; set; }

        public int employee_status_id { get; set; }

        public int company_id { get; set; }

        public int bank_id { get; set; }

        public int tin { get; set; }

        public int telephone_number { get; set; }

        public int rdo_id { get; set; }

        public int position_id { get; set; }

        //[Required]
        public int created_by_id { get; set; }

        //[Required]
        public DateTime date_created { get; set; }

        public int modified_by_id { get; set; }

        public DateTime date_modified { get; set; }
    }
}