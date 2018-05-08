using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class employee_addresses
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id{ get; set; }
        public int employee_id { get; set; }
		public string unit_room_number_floor { get; set; }
		public string building_name { get; set; }
		public string lot_block_phase_house_number { get; set; }
		public string street_name { get; set; }
		public string village_subdivision { get; set; }
		public string barangay { get; set; }
		public string town_district { get; set; }
		public int municipality_id { get; set; }
		public string city_province { get; set; }
		public int address_type_id { get; set; }
		public string zip_code { get; set; }
        public int created_by_id { get; set; }
        public DateTime date_created { get; set; }
        public int modified_by_id { get; set; }
        public DateTime date_modified { get; set; }
    }
}