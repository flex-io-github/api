using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class EmployeeList
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        //[Required]
        public string employee_code { get; set; }

        //[Required]
        public string first_name { get; set; }

        //[Required]
        public string last_name { get; set; }

        public string middle_name { get; set; }

        public string prefix { get; set; }

        public string suffix { get; set; }

        public string tfn { get; set; }

        //[Phone]
        public string mobile_number { get; set; }

        //[EmailAddress]
        public string email_address { get; set; }

        public DateTime date_of_birth { get; set; }

        public string gender { get; set; }

        public string work_type { get; set; }

        public string employee_status { get; set; }

        //[Required]
        public string created_by { get; set; }

        //[Required]
        public DateTime date_created { get; set; }

        public string modified_by { get; set; }

        public DateTime date_modified { get; set; }
    }
}
