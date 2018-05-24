CREATE OR REPLACE FUNCTION get_employee_address (employee_id INTEGER, address_type_id INTEGER) 
RETURNS TABLE (
    id INT,
    address text,
    zip_code text
)
AS $$
BEGIN
	RETURN QUERY
    SELECT ea.employee_id,
    	CONCAT_WS(' ',
            TRIM(ea.unit_room_number_floor),
            TRIM(ea.building_name), 
            TRIM(ea.lot_block_phase_house_number),
            TRIM(ea.street_name), 
            TRIM(ea.village_subdivision), 
            TRIM(ea.barangay), 
            TRIM(ea.town_district),
            TRIM(m.display),
            TRIM(ea.city_province)) AS address,
    	ea.zip_code
    FROM employee_addresses ea
    	LEFT OUTER JOIN municipality m ON m.id = ea.municipality_id
    WHERE (ea.employee_id = $1 OR $1 = 0)
    	AND (ea.address_type_id = $2 OR $2 = 0);

END; $$ 
LANGUAGE 'plpgsql';
