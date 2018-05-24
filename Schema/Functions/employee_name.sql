CREATE OR REPLACE FUNCTION employee_name(employee_id int)
RETURNS TABLE (
    id int,
    name text,
    formal_name text,
    full_name text
)
AS $$ 
BEGIN
    RETURN QUERY (SELECT e.id,
        CONCAT_WS(' ',
            TRIM(e.first_name),
            CASE WHEN LENGTH(TRIM(e.middle_name)) = 0 THEN '' 
                ELSE SUBSTR(TRIM(e.middle_name), 1, 1) || '.' END, 
            TRIM(e.last_name)
        ) || CASE WHEN TRIM(s.display) IS NULL THEN '' ELSE ', ' || TRIM(s.display) END AS name,

        CONCAT_WS(' ',
            TRIM(e.last_name) || ',',
            TRIM(e.first_name),
            CASE WHEN LENGTH(TRIM(e.middle_name)) = 0 THEN '' 
                ELSE SUBSTR(TRIM(e.middle_name), 1, 1) || '.'
            END
        ) || CASE WHEN TRIM(s.display) IS NULL THEN '' ELSE ', ' || TRIM(s.display) END as formal_name,

        CONCAT_WS(' ',
            TRIM(e.last_name) || ',',
            TRIM(e.first_name),
            TRIM(e.middle_name)
        ) || CASE WHEN TRIM(s.display) IS NULL THEN '' ELSE ', ' || TRIM(s.display) END AS full_name
    FROM employees e
        LEFT OUTER JOIN suffix s ON s.id = e.suffix_id
    WHERE e.id = employee_id OR employee_id = 0);
        
END; $$
LANGUAGE 'plpgsql';

