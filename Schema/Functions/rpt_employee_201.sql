CREATE OR REPLACE FUNCTION rpt_employee_201(employee_id int)
RETURNS TABLE (
    id int, employee_code text, formal_name text,
    "position" text, employment_type text, department text,
    cost_center text, location text, supervisor text,
    tin text, sss_number text, phic_number text, pag_ibig_number text,
    tax_code text, is_active boolean, is_union boolean,
    date_of_birth timestamp without time zone, gender text, civil_status text,
    address_registered text, zip_code_ar text, address_local text, zip_code_al text,
    pay_group text, payment_types text, payroll_frequency text,
    parameter text, date_effective timestamp without time zone, time_source text,
    shift_schedule text, pay_element_schedule text, leave_accrual_schedule text, leave_forfeit_schedule text,
    monthly_rate real, monthly_cola real, monthly_allowance real,
    daily_rate real, daily_cola real, daily_allowance real,
    hourly_rate real, hourly_cola real, hourly_allowance real,
    date_hired timestamp without time zone, date_regular timestamp without time zone, 
    date_separated timestamp without time zone, contract_start_date timestamp without time zone,
    contract_end_date timestamp without time zone, payout_type text,
    bank_account text, bank_account_type text, bank_account_number text
)
AS $$ 
BEGIN
    RETURN QUERY (
        SELECT e.id, e.employee_code, en.formal_name,
            p.display AS position, et.display AS employment_type, d.display AS department,
            cc.display AS cost_center, l.display AS location, en2.formal_name AS supervisor,
            e.tin, e.sss_number, e.phic_number, e.pag_ibig_number,
            tc.display AS tax_code, e.is_active, e.is_union,
            e.date_of_birth, g.display AS gender, cs.display AS civil_status,
            gea.address AS address_registered, gea.zip_code AS zip_code_ar,
            gea2.address AS address_local, gea2.zip_code AS zip_code_al,
            pg.display AS pay_group, pt.display AS payment_types, pf.display AS payroll_frequency,
            pr.name AS parameter, e.date_effective, ts.name AS time_source,
            '' AS shift_schedule, '' AS pay_element_schedule, '' AS leave_accrual_schedule, '' AS leave_forfeit_schedule,
            e.monthly_rate, e.monthly_cola, e.monthly_allowance,
            e.daily_rate, e.daily_cola, e.daily_allowance,
            e.hourly_rate, e.hourly_cola, e.hourly_allowance,
            e.date_hired, e.date_regular, e.date_separated, e.contract_start_date, e.contract_end_date,
            pot.name AS payout_type, ba.name AS bank_account, bat.name AS bank_account_type,
            e.bank_account_number
        FROM employees e
            INNER JOIN employee_name(0) en ON en.id = e.id
            LEFT OUTER JOIN positions p ON p.id = e.position_id
            LEFT OUTER JOIN employment_types et ON et.id = e.employment_type_id
            LEFT OUTER JOIN departments d ON d.id = e.department_id
            LEFT OUTER JOIN cost_centers cc ON cc.id = e.cost_center_id
            LEFT OUTER JOIN locations l ON l.id = e.location_id
            LEFT OUTER JOIN employees e2 ON e2.id = e.supervisor_id
            LEFT OUTER JOIN employee_name(0) en2 ON en2.id = e2.id
            LEFT OUTER JOIN tax_codes tc ON tc.id = e.tax_code_id
            LEFT OUTER JOIN genders g ON g.id = e.gender_id
            LEFT OUTER JOIN civil_status cs ON cs.id = e.civil_status_id
            LEFT OUTER JOIN get_employee_address(0, 1) gea ON gea.id = e.id
            LEFT OUTER JOIN get_employee_address(0, 2) gea2 ON gea2.id = e.id
            LEFT OUTER JOIN pay_groups pg ON pg.id = e.pay_group_id
            LEFT OUTER JOIN payment_types pt ON pt.id = e.payment_type_id
            LEFT OUTER JOIN payroll_frequencies pf ON pf.id = e.payroll_frequency_id
            LEFT OUTER JOIN parameters pr ON pr.id = e.parameter_id
            LEFT OUTER JOIN time_sources ts ON ts.id = e.time_source_id
            LEFT OUTER JOIN payout_types pot ON pot.id = e.payout_type_id
            LEFT OUTER JOIN bank_accounts ba ON ba.id = e.bank_account_id
            LEFT OUTER JOIN bank_account_types bat ON bat.id = e.bank_account_type_id
        WHERE (e.id = $1 OR $1 = 0)
    );
        
END; $$
LANGUAGE 'plpgsql';

/*
DROP FUNCTION rpt_employee_201
*/