using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;



namespace WebApi.Data
{
    public static class DbInitializer
    {
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            //===EXECUTE ALL SQL FILES IN root/Schema TO DB
            //===DEV ONLY
            var path = AppDomain.CurrentDomain.BaseDirectory;
            string schemaDir = Path.GetDirectoryName(path); //without file name
            schemaDir = Path.GetDirectoryName(schemaDir); // Temp folder
            schemaDir = Path.GetDirectoryName(schemaDir);
            schemaDir = Path.GetDirectoryName(schemaDir) + @"/Schema/";
            //string schemaFile = Path.GetDirectoryName(schemaDir) + @"/Schema/Functions/get_lookup.sql";

            string[] directories = Directory.GetDirectories(schemaDir);

            foreach (string s in directories)
            {
                string[] files = Directory.GetFiles(s);

                foreach (string a in files)
                {
                    if (a.Contains(".sql"))
                    {
                        string file = File.OpenText(a).ReadToEnd();
                        context.Database.ExecuteSqlCommand(file);
                    }

                }

            }

            //===END

            // Look for any students.
            if (context.auth_users.Any())
            {
                return;   // DB has been seeded
            }


            byte[] passwordHash, passwordSalt;
            var password = "masterkey";
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new auth_user[]
            {
                new auth_user
                    {
                        username = "admin",
                        password_hash = passwordHash,
                        password_salt = passwordSalt,
                        auth_user_role_id = 1
                    } // 1-admin
            };

            foreach (auth_user s in user)
            {
                context.auth_users.Add(s);
            }

            var authUserRole = new auth_user_role[]
            {
               new auth_user_role { name = "Administrator"},
               new auth_user_role { name = "User" },
               new auth_user_role { name = "Employee" }
            };

            foreach (auth_user_role s in authUserRole)
            {
                context.auth_user_roles.Add(s);
            }

            var payroll_frequencies = new payroll_frequencies[]
            {
                new payroll_frequencies { display = "Daily", 
                    is_include_in_payroll_cut_off_schedule = true,
                    is_include_in_payroll_cut_off_generate = false,
                    order = 1},
                new payroll_frequencies { display = "Weekly", 
                    is_include_in_payroll_cut_off_schedule = true,
                    is_include_in_payroll_cut_off_generate = false,
                    order = 2},
                new payroll_frequencies { display = "Semi-monthly", 
                    is_include_in_payroll_cut_off_schedule = true,
                    is_include_in_payroll_cut_off_generate = true,
                    order = 3},
                new payroll_frequencies { display = "Monthly", 
                    is_include_in_payroll_cut_off_schedule = true,
                    is_include_in_payroll_cut_off_generate = true,
                    order = 4},
                new payroll_frequencies { display = "Every Two Weeks", 
                    is_include_in_payroll_cut_off_schedule = true,
                    is_include_in_payroll_cut_off_generate = false,
                    order = 5},
            };

            foreach (payroll_frequencies s in payroll_frequencies)
            {
                context.payroll_frequencies.Add(s);
            }

            var paymentTypes = new payment_types[]
            {
               new payment_types { display = "Monthly Paid", is_flat_rate = true },
               new payment_types { display = "Daily Paid", is_flat_rate = false },
               new payment_types { display = "Hourly Paid", is_flat_rate = false }
            };

            foreach (payment_types s in paymentTypes)
            {
                context.payment_types.Add(s);
            }

            var timeSources = new time_sources[]
            {
               new time_sources { name = "Timesheet", is_create_timesheet = true, is_active = true },
               new time_sources { name = "Assume Perfect Attendance", is_create_timesheet = true, is_active = false },
               new time_sources { name = "Time Summary", is_create_timesheet = false, is_active = true },
               new time_sources { name = "Flexi Per Period", is_create_timesheet = true, is_active = false }
            };

            foreach (time_sources s in timeSources)
            {
                context.time_sources.Add(s);
            }

            var taxComputations = new tax_computations[]
            {
               new tax_computations { name = "Standard" },
               new tax_computations { name = "Monthly" },
               new tax_computations { name = "Normalize" }
            };

            foreach (tax_computations s in taxComputations)
            {
                context.tax_computations.Add(s);
            }

            var taxBasis = new tax_basis[]
            {
               new tax_basis { name = "Gross Income", display = "", is_active = false },
               new tax_basis { name = "Combined regular and supplementary compensation", display = "Combine", is_active = true },
               new tax_basis { name = "Separate regular and supplementary compensation", display = "Separate", is_active = true }
            };

            foreach (tax_basis s in taxBasis)
            {
                context.tax_basis.Add(s);
            }

            var _13thMonthTypes = new _13th_month_types[]
            {
               new _13th_month_types { name = "Based on Gross" },
               new _13th_month_types { name = "Gross - Deductions Excluding Loans" }
            };

            foreach (_13th_month_types s in _13thMonthTypes)
            {
                context._13th_month_types.Add(s);
            }

            var _13thMonthRoundDirections = new _13th_month_round_directions[]
            {
               new _13th_month_round_directions { name = "Round Up" },
               new _13th_month_round_directions { name = "Round Down" }
            };

            foreach (_13th_month_round_directions s in _13thMonthRoundDirections)
            {
                context._13th_month_round_directions.Add(s);
            }

            var dateBasis = new date_basis[]
            {
               new date_basis { name = "Date Hired", is_active = true },
               new date_basis { name = "Date Regular", is_active = true }
            };

            foreach (date_basis s in dateBasis)
            {
                context.date_basis.Add(s);
            }

            var payrollPeriods = new payroll_periods[]
            {
                new payroll_periods { name = "1st Period", is_active = true, period_order = 10, payroll_period_type_id = 1,
                    is_regular_payroll_period = true, is_13th_month_pay = false, is_final_pay = false, is_annualization = false,
                    is_special_payroll = false },
                new payroll_periods { name = "2nd Period", is_active = true, period_order = 20, payroll_period_type_id = 1,
                    is_regular_payroll_period = true, is_13th_month_pay = false, is_final_pay = false, is_annualization = false,
                    is_special_payroll = false },
                new payroll_periods { name = "3rd Period", is_active = true, period_order = 30, payroll_period_type_id = 1,
                    is_regular_payroll_period = true, is_13th_month_pay = false, is_final_pay = false, is_annualization = false,
                    is_special_payroll = false },
                new payroll_periods { name = "4th Period", is_active = true, period_order = 40, payroll_period_type_id = 1,
                    is_regular_payroll_period = true, is_13th_month_pay = false, is_final_pay = false, is_annualization = false,
                    is_special_payroll = false },
                new payroll_periods { name = "5th Period", is_active = true, period_order = 50, payroll_period_type_id = 1,
                    is_regular_payroll_period = true, is_13th_month_pay = false, is_final_pay = false, is_annualization = false,
                    is_special_payroll = false },
                new payroll_periods { name = "13th Month Pay", is_active = true, period_order = 60, payroll_period_type_id = 2,
                    is_regular_payroll_period = false, is_13th_month_pay = true, is_final_pay = false, is_annualization = false,
                    is_special_payroll = false },
                new payroll_periods { name = "Final Pay", is_active = true, period_order = 70, payroll_period_type_id = 3,
                    is_regular_payroll_period = false, is_13th_month_pay = false, is_final_pay = true, is_annualization = false,
                    is_special_payroll = false },
                new payroll_periods { name = "Annualization", is_active = true, period_order = 80, payroll_period_type_id = 4,
                    is_regular_payroll_period = false, is_13th_month_pay = false, is_final_pay = false, is_annualization = true,
                    is_special_payroll = false },
            };

            foreach (payroll_periods s in payrollPeriods)
            {
                context.payroll_periods.Add(s);
            }

            var payrollPeriodTypes = new payroll_period_types[]
            {
               new payroll_period_types { display = "REGULAR PAYROLL", name = "Regular Payroll" },
               new payroll_period_types { display = "13TH MONTH", name = "13th Month" },
               new payroll_period_types { display = "FINAL PAY", name = "Final Pay" },
               new payroll_period_types { display = "ANNUALIZATION", name = "Annualization" },
               new payroll_period_types { display = "SPECIAL PAYROLL", name = "Special Payroll" },
            };

            foreach (payroll_period_types s in payrollPeriodTypes)
            {
                context.payroll_period_types.Add(s);
            }

            var holidayTypes = new holiday_types[]
            {
               new holiday_types { display = "LEGAL", name = "REGULAR" },
               new holiday_types { display = "SPECIAL", name = "SPECIAL" },
               new holiday_types { display = "SPECIAL 2", name = "SPECIAL 2" }
            };

            foreach (holiday_types s in holidayTypes)
            {
                context.holiday_types.Add(s);
            }

            var dayTypes = new day_types[]
            {
                new day_types { display = "REG", name = "Regular Day", is_rest_day = false, is_holiday = false, holiday_type_id = 0,
                    is_legal = false, is_special = false, is_special2 = false, is_regular = true },
                new day_types { display = "RD", name = "Rest Day", is_rest_day = true, is_holiday = false, holiday_type_id = 0,
                    is_legal = false, is_special = false, is_special2 = false, is_regular = false },
                new day_types { display = "RD2", name = "Rest Day 2", is_rest_day = true, is_holiday = false, holiday_type_id = 0,
                    is_legal = false, is_special = false, is_special2 = false, is_regular = false },
                new day_types { display = "RD3", name = "Rest Day 3", is_rest_day = true, is_holiday = false, holiday_type_id = 0,
                    is_legal = false, is_special = false, is_special2 = false, is_regular = false },
                
                new day_types { display = "LH", name = "Regular Holiday", is_rest_day = false, is_holiday = true, holiday_type_id = 1,
                    is_legal = true, is_special = false, is_special2 = false, is_regular = false },
                new day_types { display = "LR", name = "Regular Holiday Rest Day", is_rest_day = true, is_holiday = true, holiday_type_id = 1,
                    is_legal = true, is_special = false, is_special2 = false, is_regular = false },
                new day_types { display = "LR2", name = "Regular Holiday Rest Day 2", is_rest_day = true, is_holiday = true, holiday_type_id = 1,
                    is_legal = true, is_special = false, is_special2 = false, is_regular = false },
                new day_types { display = "LR3", name = "Regular Holiday Rest Day 3", is_rest_day = true, is_holiday = true, holiday_type_id = 1,
                    is_legal = true, is_special = false, is_special2 = false, is_regular = false },

                new day_types { display = "SH", name = "Special Holiday", is_rest_day = false, is_holiday = true, holiday_type_id = 2,
                    is_legal = false, is_special = true, is_special2 = false, is_regular = false },
                new day_types { display = "SR", name = "Special Holiday Rest Day", is_rest_day = true, is_holiday = true, holiday_type_id = 2,
                    is_legal = false, is_special = true, is_special2 = false, is_regular = false },
                new day_types { display = "SR2", name = "Special Holiday Rest Day 2", is_rest_day = true, is_holiday = true, holiday_type_id = 2,
                    is_legal = false, is_special = true, is_special2 = false, is_regular = false },
                new day_types { display = "SR3", name = "Special Holiday Rest Day 3", is_rest_day = true, is_holiday = true, holiday_type_id = 2,
                    is_legal = false, is_special = true, is_special2 = false, is_regular = false },

                new day_types { display = "SH2", name = "Special Holiday 2", is_rest_day = false, is_holiday = true, holiday_type_id = 3,
                    is_legal = false, is_special = false, is_special2 = true, is_regular = false },
                new day_types { display = "S2R", name = "Special Holiday 2 Rest Day", is_rest_day = true, is_holiday = true, holiday_type_id = 3,
                    is_legal = false, is_special = false, is_special2 = true, is_regular = false },
                new day_types { display = "S2R2", name = "Special Holiday 2 Rest Day 2", is_rest_day = true, is_holiday = true, holiday_type_id = 3,
                    is_legal = false, is_special = false, is_special2 = true, is_regular = false },
                new day_types { display = "S2R3", name = "Special Holiday 2 Rest Day 3", is_rest_day = true, is_holiday = true, holiday_type_id = 3,
                    is_legal = false, is_special = false, is_special2 = true, is_regular = false }
            };

            foreach (day_types s in dayTypes)
            {
                context.day_types.Add(s);
            }

            var hourTypes = new hour_types[]
            {
                new hour_types { display = "BASIC", name = "Basic", sys_code = "BASIC",
                    is_core_time = true, is_overtime = false, is_break_time = false, is_nd = false},
                new hour_types { display = "OT", name = "Overtime", sys_code = "OT",
                    is_core_time = false, is_overtime = true, is_break_time = false, is_nd = false},
                new hour_types { display = "ND", name = "Night Differential", sys_code = "ND",
                    is_core_time = true, is_overtime = false, is_break_time = false, is_nd = true},
                new hour_types { display = "NDOT", name = "Night Differential Overtime", sys_code = "NDOT",
                    is_core_time = false, is_overtime = true, is_break_time = false, is_nd = true},
                new hour_types { display = "FIXED BREAK", name = "Fixed Break", sys_code = "FIXED BREAK",
                    is_core_time = false, is_overtime = false, is_break_time = true, is_nd = false},
                new hour_types { display = "FLEXI BREAK", name = "Flexi Break", sys_code = "FLEXI BREAK",
                    is_core_time = false, is_overtime = false, is_break_time = true, is_nd = false},
                new hour_types { display = "PAID BREAK", name = "Paid Break", sys_code = "PAID BREAK",
                    is_core_time = false, is_overtime = false, is_break_time = true, is_nd = false},
                new hour_types { display = "PURGE", name = "Purge", sys_code = "PURGE",
                    is_core_time = false, is_overtime = false, is_break_time = false, is_nd = false},
                new hour_types { display = "NONE", name = "None", sys_code = "NONE",
                    is_core_time = false, is_overtime = false, is_break_time = false, is_nd = false},
                new hour_types { display = "OT EXCESS", name = "Overtime Excess", sys_code = "OTEXCESS",
                    is_core_time = false, is_overtime = true, is_break_time = false, is_nd = false},
                new hour_types { display = "NDOT EXCESS", name = "Night Differential Overtime Excess", sys_code = "NDOTEXCESS",
                    is_core_time = false, is_overtime = true, is_break_time = false, is_nd = true},
            };

            foreach (hour_types s in hourTypes)
            {
                context.hour_types.Add(s);
            }

            var interestRateTypes = new interest_rate_types[]
            {
               new interest_rate_types { name = "Percent" },
               new interest_rate_types { name = "Amount" }
            };

            foreach (interest_rate_types s in interestRateTypes)
            {
                context.interest_rate_types.Add(s);
            }
            
            var interestTypes = new interest_types[]
            {
               new interest_types { name = "Fixed", is_active = true },
               new interest_types { name = "Diminishing", is_active = true }
            };

            foreach (interest_types s in interestTypes)
            {
                context.interest_types.Add(s);
            }

            var payTaxTypes = new pay_tax_types[]
            {
                new pay_tax_types { display = "BASICSALARY", name = "Taxable (Basic Salary)", 
                    is_earning = true, is_minimum_wage_earner_exempt = true, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = false, is_13th_month_pay = false},
                new pay_tax_types { display = "REPRESENTATION", name = "Taxable (Representation)", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = false, is_13th_month_pay = false},
                new pay_tax_types { display = "TRANSPORTATION", name = "Taxable (Transportation)", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = false, is_13th_month_pay = false},
                new pay_tax_types { display = "COLA", name = "Taxable (Cost of living allowance)", 
                    is_earning = true, is_minimum_wage_earner_exempt = true, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = false, is_13th_month_pay = false},
                new pay_tax_types { display = "FIXEDHOUSING", name = "Taxable (Fixed housing allowance)", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = false, is_13th_month_pay = false},
                new pay_tax_types { display = "OTHER1", name = "Taxable (Others Regular 1)", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = false, is_13th_month_pay = false},
                new pay_tax_types { display = "OTHER2", name = "Taxable (Others Regular 2)", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = false, is_13th_month_pay = false},
                new pay_tax_types { display = "COMMISSION", name = "Taxable (Commission)", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = true, is_13th_month_pay = false},
                new pay_tax_types { display = "PROFITSHARING", name = "Taxable (Profit sharing)", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = true, is_13th_month_pay = false},
                new pay_tax_types { display = "FEES", name = "Taxable (Fees including Director's fees)", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = true, is_13th_month_pay = false},
                new pay_tax_types { display = "HAZARDPAY", name = "Taxable (Hazard pay)", 
                    is_earning = true, is_minimum_wage_earner_exempt = true, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = true, is_13th_month_pay = false},
                new pay_tax_types { display = "OTHSUPP1", name = "Taxable (Others Supplementary 1)", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = true, is_13th_month_pay = false},
                new pay_tax_types { display = "OTHSUPP2", name = "Taxable (Others Supplementary 2)", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = true, is_13th_month_pay = false},
                new pay_tax_types { display = "NTAXCONTRIBUTION", name = "Non-taxable (SSS, GSIS, PHIC & PagIbig contributions & union dues)", 
                    is_earning = false, is_minimum_wage_earner_exempt = true, is_taxable = false, 
                    taxable_mult = -1, is_supplementary = false, is_13th_month_pay = false},
                new pay_tax_types { display = "NTAXCOMPENSATION", name = "Non-taxable (Salaries and other forms of compensation)", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = false, 
                    taxable_mult = 0, is_supplementary = false, is_13th_month_pay = false},
                new pay_tax_types { display = "13THMONTH", name = "13th Month pay and other benefits", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = false, 
                    taxable_mult = 0, is_supplementary = true, is_13th_month_pay = true},
                new pay_tax_types { display = "PREMIUM", name = "Premium paid on health insurance", 
                    is_earning = false, is_minimum_wage_earner_exempt = true, is_taxable = false, 
                    taxable_mult = -1, is_supplementary = false, is_13th_month_pay = false},
                new pay_tax_types { display = "FRINGEBENEFIT", name = "Fringe Benefit Taxable", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = false, 
                    taxable_mult = 0, is_supplementary = false, is_13th_month_pay = false},
                new pay_tax_types { display = "DEMINIMISBENEFITS", name = "Non-taxable (De Minimis Benefits)", 
                    is_earning = true, is_minimum_wage_earner_exempt = false, is_taxable = false, 
                    taxable_mult = 0, is_supplementary = false, is_13th_month_pay = false},
                new pay_tax_types { display = "HOLIDAYPAY", name = "Taxable (Holiday Pay)", 
                    is_earning = true, is_minimum_wage_earner_exempt = true, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = true, is_13th_month_pay = false},
                new pay_tax_types { display = "OVERTIMEPAY", name = "Taxable (Overtime Pay)", 
                    is_earning = true, is_minimum_wage_earner_exempt = true, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = true, is_13th_month_pay = false},
                new pay_tax_types { display = "NIGHTSHIFTDIFFERENTIAL", name = "Taxable (Night Shift Differential)", 
                    is_earning = true, is_minimum_wage_earner_exempt = true, is_taxable = true, 
                    taxable_mult = 1, is_supplementary = true, is_13th_month_pay = false},
            };

            foreach (pay_tax_types s in payTaxTypes)
            {
                context.pay_tax_types.Add(s);
            }

            var timeTypes = new time_types[]
            {
               new time_types { name = "Minute" },
               new time_types { name = "Hour" },
               new time_types { name = "Day" }
            };

            foreach (time_types s in timeTypes)
            {
                context.time_types.Add(s);
            }

             var timeUnits = new time_units[]
            {
                new time_units { name = "Per Minute", is_active = false, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Half Hour", is_active = false, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Hour", is_active = true, is_include_basic = true, is_include_ot = true, is_include_nd = true, is_include_ndot = true, is_minimum = true, is_exclude_leave = false, is_exclude_ob = true, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = true, is_rest_day2 = true, is_rest_day3 = true, is_legal_holiday = true, is_legal_rest_day = true, is_legal_rest_day2 = true, is_legal_rest_day3 = true, is_special_holiday = true, is_special_rest_day = true, is_special_rest_day2 = true, is_special_rest_day3 = true, is_special_holiday2 = true, is_special2_rest_day = true, is_special2_rest_day2 = true, is_special2_rest_day3 = true, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Half Day", is_active = false, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Day", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = true, is_exclude_leave = true, is_exclude_ob = true, is_deduct_absent = false, is_deduct_tardy = true, is_deduct_mid_break = true, is_deduct_undertime = true, is_deduct_unpaid_holiday = false, is_deduct_halfday = true, is_prorated = false, is_regular_day = true, is_rest_day = true, is_rest_day2 = true, is_rest_day3 = true, is_legal_holiday = true, is_legal_rest_day = true, is_legal_rest_day2 = true, is_legal_rest_day3 = true, is_special_holiday = true, is_special_rest_day = true, is_special_rest_day2 = true, is_special_rest_day3 = true, is_special_holiday2 = true, is_special2_rest_day = true, is_special2_rest_day2 = true, is_special2_rest_day3 = true, is_use_formula = true, is_de_minimis = true, is_include_tardy = true, is_include_midbreak = true, is_include_undertime = true, is_deduct_leave_hours = true},
                new time_units { name = "Per Period", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = true, is_exclude_ob = true, is_deduct_absent = true, is_deduct_tardy = true, is_deduct_mid_break = true, is_deduct_undertime = true, is_deduct_unpaid_holiday = true, is_deduct_halfday = true, is_prorated = false, is_regular_day = false, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Month", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = true, is_exclude_ob = true, is_deduct_absent = true, is_deduct_tardy = true, is_deduct_mid_break = true, is_deduct_undertime = true, is_deduct_unpaid_holiday = true, is_deduct_halfday = true, is_prorated = false, is_regular_day = false, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = true, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Half Day Absent", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Whole Day Absent", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Tardy Count", is_active = false, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Minute Tardy", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Midbreak Count", is_active = false, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Minute Midbreak", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Undertime Count", is_active = false, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Minute Undertime", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Occurrence of a Day", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = true, is_regular_day = true, is_rest_day = true, is_rest_day2 = true, is_rest_day3 = true, is_legal_holiday = true, is_legal_rest_day = true, is_legal_rest_day2 = true, is_legal_rest_day3 = true, is_special_holiday = true, is_special_rest_day = true, is_special_rest_day2 = true, is_special_rest_day3 = true, is_special_holiday2 = true, is_special2_rest_day = true, is_special2_rest_day2 = true, is_special2_rest_day3 = true, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Day On Leave", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = true, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = true, is_legal_rest_day = true, is_legal_rest_day2 = true, is_legal_rest_day3 = true, is_special_holiday = true, is_special_rest_day = true, is_special_rest_day2 = true, is_special_rest_day3 = true, is_special_holiday2 = true, is_special2_rest_day = true, is_special2_rest_day2 = true, is_special2_rest_day3 = true, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Year", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = false, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = false, is_de_minimis = true, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Semester", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = false, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = false, is_legal_rest_day = false, is_legal_rest_day2 = false, is_legal_rest_day3 = false, is_special_holiday = false, is_special_rest_day = false, is_special_rest_day2 = false, is_special_rest_day3 = false, is_special_holiday2 = false, is_special2_rest_day = false, is_special2_rest_day2 = false, is_special2_rest_day3 = false, is_use_formula = false, is_de_minimis = true, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
                new time_units { name = "Per Paid Holiday", is_active = true, is_include_basic = false, is_include_ot = false, is_include_nd = false, is_include_ndot = false, is_minimum = false, is_exclude_leave = false, is_exclude_ob = false, is_deduct_absent = false, is_deduct_tardy = false, is_deduct_mid_break = false, is_deduct_undertime = false, is_deduct_unpaid_holiday = false, is_deduct_halfday = false, is_prorated = false, is_regular_day = false, is_rest_day = false, is_rest_day2 = false, is_rest_day3 = false, is_legal_holiday = true, is_legal_rest_day = true, is_legal_rest_day2 = true, is_legal_rest_day3 = true, is_special_holiday = true, is_special_rest_day = true, is_special_rest_day2 = true, is_special_rest_day3 = true, is_special_holiday2 = true, is_special2_rest_day = true, is_special2_rest_day2 = true, is_special2_rest_day3 = true, is_use_formula = true, is_de_minimis = false, is_include_tardy = false, is_include_midbreak = false, is_include_undertime = false, is_deduct_leave_hours = false},
            };

            foreach (time_units s in timeUnits)
            {
                context.time_units.Add(s);
            }

            var payrollHourTypes = new payroll_hour_types[]
            {
               new payroll_hour_types { name = "Basic", time_unit_id = 0 },
               new payroll_hour_types { name = "OT", time_unit_id = 3 },
               new payroll_hour_types { name = "ND", time_unit_id = 3 },
               new payroll_hour_types { name = "NDOT", time_unit_id = 3 },
               new payroll_hour_types { name = "OT EXCESS", time_unit_id = 3 },
               new payroll_hour_types { name = "NDOT EXCESS", time_unit_id = 3 },
               new payroll_hour_types { name = "Absent", time_unit_id = 5 },
               new payroll_hour_types { name = "Tardy", time_unit_id = 1 },
               new payroll_hour_types { name = "Undertime", time_unit_id = 1 },
            };

            foreach (payroll_hour_types s in payrollHourTypes)
            {
                context.payroll_hour_types.Add(s);
            }

            var payElementTypes = new pay_element_types[]
            {
               new pay_element_types { display = "EARNING", name = "Earning" },
               new pay_element_types { display = "DEDUCTION", name = "Deduction" },
               new pay_element_types { display = "LOAN", name = "Loan" },
               new pay_element_types { display = "ALLOWANCE", name = "Allowance" }
            };

            foreach (pay_element_types s in payElementTypes)
            {
                context.pay_element_types.Add(s);
            }

            var Rates = new rates[]
            {
               new rates { name = "Hourly Rate" },
               new rates { name = "Daily Rate" },
               new rates { name = "Monthly Rate" },
               new rates { name = "Basic Pay" },
               new rates { name = "Hourly Allowance" },
               new rates { name = "Daily Allowance" },
               new rates { name = "Monthly Allowance" },
               new rates { name = "Hourly COLA" },
               new rates { name = "Daily COLA" },
               new rates { name = "Monthly COLA" },
               new rates { name = "Net Pay" }
            };

            foreach (rates s in Rates)
            {
                context.rates.Add(s);
            }

            var payElementDisplays = new pay_element_displays[]
            {
               new pay_element_displays { name = "Code" },
               new pay_element_displays { name = "Group Code" },
               new pay_element_displays { name = "Name" },
               new pay_element_displays { name = "Payroll Register Group Code" }
            };

            foreach (pay_element_displays s in payElementDisplays)
            {
                context.pay_element_displays.Add(s);
            }

            var payoutTypes = new payout_types[]
            {
               new payout_types { name = "Bank Account" },
               new payout_types { name = "Cash" },
               new payout_types { name = "Cheque" }
            };

            foreach (payout_types s in payoutTypes)
            {
                context.payout_types.Add(s);
            }

            var bankAccountTypes = new bank_account_types[]
            {
               new bank_account_types { name = "SA" },
               new bank_account_types { name = "CA" }
            };

            foreach (bank_account_types s in bankAccountTypes)
            {
                context.bank_account_types.Add(s);
            }

            var hdmf = new hdmf[]
            {
                new hdmf { bracket = 1, range1 = 0, range2 = 1500, percent_ee = 1, percent_er = 2, 
                    min_ee = 100, min_er = 100, max_ee = 100, max_er = 100, non_taxable_amount = 100, },
                new hdmf { bracket = 2, range1 = 0, range2 = 999999999.99f, percent_ee = 2, percent_er = 2, 
                    min_ee = 100, min_er = 100, max_ee = 100, max_er = 100, non_taxable_amount = 100 }
            };

            foreach (hdmf s in hdmf)
            {
                context.hdmf.Add(s);
            }

            var sss = new sss[]
            {
                new sss { bracket = 1, range1 = 1000, range2 = 1249.99f, monthly_salary_credit = 1000f, sss_ee = 36.3f, sss_er = 73.7f, ecc_er = 10, sss_total = 120 }, 
                new sss { bracket = 2, range1 = 1250, range2 = 1749.99f, monthly_salary_credit = 1500f, sss_ee = 54.5f, sss_er = 110.5f, ecc_er = 10, sss_total = 175 }, 
                new sss { bracket = 3, range1 = 1750, range2 = 2249.99f, monthly_salary_credit = 2000f, sss_ee = 72.7f, sss_er = 147.3f, ecc_er = 10, sss_total = 230 }, 
                new sss { bracket = 4, range1 = 2250, range2 = 2749.99f, monthly_salary_credit = 2500f, sss_ee = 90.8f, sss_er = 184.2f, ecc_er = 10, sss_total = 285 }, 
                new sss { bracket = 5, range1 = 2750, range2 = 3249.99f, monthly_salary_credit = 3000f, sss_ee = 109f, sss_er = 221f, ecc_er = 10, sss_total = 340 }, 
                new sss { bracket = 6, range1 = 3250, range2 = 3749.99f, monthly_salary_credit = 3500f, sss_ee = 127.2f, sss_er = 257.8f, ecc_er = 10, sss_total = 395 }, 
                new sss { bracket = 7, range1 = 3750, range2 = 4249.99f, monthly_salary_credit = 4000f, sss_ee = 145.3f, sss_er = 294.7f, ecc_er = 10, sss_total = 450 }, 
                new sss { bracket = 8, range1 = 4250, range2 = 4749.99f, monthly_salary_credit = 4500f, sss_ee = 163.5f, sss_er = 331.5f, ecc_er = 10, sss_total = 505 }, 
                new sss { bracket = 9, range1 = 4750, range2 = 5249.99f, monthly_salary_credit = 5000f, sss_ee = 181.7f, sss_er = 368.3f, ecc_er = 10, sss_total = 560 }, 
                new sss { bracket = 10, range1 = 5250, range2 = 5749.99f, monthly_salary_credit = 5500f, sss_ee = 199.8f, sss_er = 405.2f, ecc_er = 10, sss_total = 615 }, 
                new sss { bracket = 11, range1 = 5750, range2 = 6249.99f, monthly_salary_credit = 6000f, sss_ee = 218f, sss_er = 442f, ecc_er = 10, sss_total = 670 }, 
                new sss { bracket = 12, range1 = 6250, range2 = 6749.99f, monthly_salary_credit = 6500f, sss_ee = 236.2f, sss_er = 478.8f, ecc_er = 10, sss_total = 725 }, 
                new sss { bracket = 13, range1 = 6750, range2 = 7249.99f, monthly_salary_credit = 7000f, sss_ee = 254.3f, sss_er = 515.7f, ecc_er = 10, sss_total = 780 }, 
                new sss { bracket = 14, range1 = 7250, range2 = 7749.99f, monthly_salary_credit = 7500f, sss_ee = 272.5f, sss_er = 552.5f, ecc_er = 10, sss_total = 835 }, 
                new sss { bracket = 15, range1 = 7750, range2 = 8249.99f, monthly_salary_credit = 8000f, sss_ee = 290.7f, sss_er = 589.3f, ecc_er = 10, sss_total = 890 }, 
                new sss { bracket = 16, range1 = 8250, range2 = 8749.99f, monthly_salary_credit = 8500f, sss_ee = 308.8f, sss_er = 626.2f, ecc_er = 10, sss_total = 945 }, 
                new sss { bracket = 17, range1 = 8750, range2 = 9249.99f, monthly_salary_credit = 9000f, sss_ee = 327f, sss_er = 663f, ecc_er = 10, sss_total = 1000 }, 
                new sss { bracket = 18, range1 = 9250, range2 = 9749.99f, monthly_salary_credit = 9500f, sss_ee = 345.2f, sss_er = 699.8f, ecc_er = 10, sss_total = 1055 }, 
                new sss { bracket = 19, range1 = 9750, range2 = 10249.99f, monthly_salary_credit = 10000f, sss_ee = 363.3f, sss_er = 736.7f, ecc_er = 10, sss_total = 1110 }, 
                new sss { bracket = 20, range1 = 10250, range2 = 10749.99f, monthly_salary_credit = 10500f, sss_ee = 381.5f, sss_er = 773.5f, ecc_er = 10, sss_total = 1165 }, 
                new sss { bracket = 21, range1 = 10750, range2 = 11249.99f, monthly_salary_credit = 11000f, sss_ee = 399.7f, sss_er = 810.3f, ecc_er = 10, sss_total = 1220 }, 
                new sss { bracket = 22, range1 = 11250, range2 = 11749.99f, monthly_salary_credit = 11500f, sss_ee = 417.8f, sss_er = 847.2f, ecc_er = 10, sss_total = 1275 }, 
                new sss { bracket = 23, range1 = 11750, range2 = 12249.99f, monthly_salary_credit = 12000f, sss_ee = 436f, sss_er = 884f, ecc_er = 10, sss_total = 1330 }, 
                new sss { bracket = 24, range1 = 12250, range2 = 12749.99f, monthly_salary_credit = 12500f, sss_ee = 454.2f, sss_er = 920.8f, ecc_er = 10, sss_total = 1385 }, 
                new sss { bracket = 25, range1 = 12750, range2 = 13249.99f, monthly_salary_credit = 13000f, sss_ee = 472.3f, sss_er = 957.7f, ecc_er = 10, sss_total = 1440 }, 
                new sss { bracket = 26, range1 = 13250, range2 = 13749.99f, monthly_salary_credit = 13500f, sss_ee = 490.5f, sss_er = 994.5f, ecc_er = 10, sss_total = 1495 }, 
                new sss { bracket = 27, range1 = 13750, range2 = 14249.99f, monthly_salary_credit = 14000f, sss_ee = 508.7f, sss_er = 1031.3f, ecc_er = 10, sss_total = 1550 }, 
                new sss { bracket = 28, range1 = 14250, range2 = 14749.99f, monthly_salary_credit = 14500f, sss_ee = 526.8f, sss_er = 1068.2f, ecc_er = 10, sss_total = 1605 }, 
                new sss { bracket = 29, range1 = 14750, range2 = 15249.99f, monthly_salary_credit = 15000f, sss_ee = 545f, sss_er = 1105f, ecc_er = 30, sss_total = 1680 }, 
                new sss { bracket = 30, range1 = 15250, range2 = 15749.99f, monthly_salary_credit = 15500f, sss_ee = 563.2f, sss_er = 1141.8f, ecc_er = 30, sss_total = 1735 }, 
                new sss { bracket = 31, range1 = 15750, range2 = 999999999.99f, monthly_salary_credit = 16000f, sss_ee = 581.3f, sss_er = 1178.7f, ecc_er = 30, sss_total = 1790 }

            };

            foreach (sss s in sss)
            {
                context.sss.Add(s);
            }

            var philHealth = new philhealth[]
            {
                new philhealth { bracket = 1, range1 = 0.01f, range2 = 8999.99f, phic_ee = 100f, phic_er = 100f, salary_base = 8000, total = 200 }, 
                new philhealth { bracket = 2, range1 = 9000f, range2 = 9999.99f, phic_ee = 112.5f, phic_er = 112.5f, salary_base = 9000, total = 225 }, 
                new philhealth { bracket = 3, range1 = 10000f, range2 = 10999.99f, phic_ee = 125f, phic_er = 125f, salary_base = 10000, total = 250 }, 
                new philhealth { bracket = 4, range1 = 11000f, range2 = 11999.99f, phic_ee = 137.5f, phic_er = 137.5f, salary_base = 11000, total = 275 }, 
                new philhealth { bracket = 5, range1 = 12000f, range2 = 12999.99f, phic_ee = 150f, phic_er = 150f, salary_base = 12000, total = 300 }, 
                new philhealth { bracket = 6, range1 = 13000f, range2 = 13999.99f, phic_ee = 162.5f, phic_er = 162.5f, salary_base = 13000, total = 325 }, 
                new philhealth { bracket = 7, range1 = 14000f, range2 = 14999.99f, phic_ee = 175f, phic_er = 175f, salary_base = 14000, total = 350 }, 
                new philhealth { bracket = 8, range1 = 15000f, range2 = 15999.99f, phic_ee = 187.5f, phic_er = 187.5f, salary_base = 15000, total = 375 }, 
                new philhealth { bracket = 9, range1 = 16000f, range2 = 16999.99f, phic_ee = 200f, phic_er = 200f, salary_base = 16000, total = 400 }, 
                new philhealth { bracket = 10, range1 = 17000f, range2 = 17999.99f, phic_ee = 212.5f, phic_er = 212.5f, salary_base = 17000, total = 425 }, 
                new philhealth { bracket = 11, range1 = 18000f, range2 = 18999.99f, phic_ee = 225f, phic_er = 225f, salary_base = 18000, total = 450 }, 
                new philhealth { bracket = 12, range1 = 19000f, range2 = 19999.99f, phic_ee = 237.5f, phic_er = 237.5f, salary_base = 19000, total = 475 }, 
                new philhealth { bracket = 13, range1 = 20000f, range2 = 20999.99f, phic_ee = 250f, phic_er = 250f, salary_base = 20000, total = 500 }, 
                new philhealth { bracket = 14, range1 = 21000f, range2 = 21999.99f, phic_ee = 262.5f, phic_er = 262.5f, salary_base = 21000, total = 525 }, 
                new philhealth { bracket = 15, range1 = 22000f, range2 = 22999.99f, phic_ee = 275f, phic_er = 275f, salary_base = 22000, total = 550 }, 
                new philhealth { bracket = 16, range1 = 23000f, range2 = 23999.99f, phic_ee = 287.5f, phic_er = 287.5f, salary_base = 23000, total = 575 }, 
                new philhealth { bracket = 17, range1 = 24000f, range2 = 24999.99f, phic_ee = 300f, phic_er = 300f, salary_base = 24000, total = 600 }, 
                new philhealth { bracket = 18, range1 = 25000f, range2 = 25999.99f, phic_ee = 312.5f, phic_er = 312.5f, salary_base = 25000, total = 625 }, 
                new philhealth { bracket = 19, range1 = 26000f, range2 = 26999.99f, phic_ee = 325f, phic_er = 325f, salary_base = 26000, total = 650 }, 
                new philhealth { bracket = 20, range1 = 27000f, range2 = 27999.99f, phic_ee = 337.5f, phic_er = 337.5f, salary_base = 27000, total = 675 }, 
                new philhealth { bracket = 21, range1 = 28000f, range2 = 28999.99f, phic_ee = 350f, phic_er = 350f, salary_base = 28000, total = 700 }, 
                new philhealth { bracket = 22, range1 = 29000f, range2 = 29999.99f, phic_ee = 362.5f, phic_er = 362.5f, salary_base = 29000, total = 725 }, 
                new philhealth { bracket = 23, range1 = 30000f, range2 = 30999.99f, phic_ee = 375f, phic_er = 375f, salary_base = 30000, total = 750 }, 
                new philhealth { bracket = 24, range1 = 31000f, range2 = 31999.99f, phic_ee = 387.5f, phic_er = 387.5f, salary_base = 31000, total = 775 }, 
                new philhealth { bracket = 25, range1 = 32000f, range2 = 32999.99f, phic_ee = 400f, phic_er = 400f, salary_base = 32000, total = 800 }, 
                new philhealth { bracket = 26, range1 = 33000f, range2 = 33999.99f, phic_ee = 412.5f, phic_er = 412.5f, salary_base = 33000, total = 825 }, 
                new philhealth { bracket = 27, range1 = 34000f, range2 = 34999.99f, phic_ee = 425f, phic_er = 425f, salary_base = 34000, total = 850 }, 
                new philhealth { bracket = 28, range1 = 35000f, range2 = 9999999.99f, phic_ee = 437.5f, phic_er = 437.5f, salary_base = 35000, total = 875 }
            };

            foreach (philhealth s in philHealth)
            {
                context.philhealth.Add(s);
            }

            var philhealthVer2 = new philhealth_ver2[]
            {
                new philhealth_ver2 { bracket = 1, range1 = 0.01f, range2 = 7000f, contribution_type_id = 2, phic_ee = 105f, phic_er = 105f }, 
                new philhealth_ver2 { bracket = 2, range1 = 7000.01f, range2 = 50000f, contribution_type_id = 1, phic_ee = 1.5f, phic_er = 1.5f }, 
                new philhealth_ver2 { bracket = 3, range1 = 50000.01f, range2 = 999999999.99f, contribution_type_id = 2, phic_ee = 750f, phic_er = 750f }
            };

            foreach (philhealth_ver2 s in philhealthVer2)
            {
                context.philhealth_ver2.Add(s);
            }

            context.SaveChanges();

            //var enrollments = new Enrollment[]
            //{
            //    new Enrollment {
            //        StudentID = students.Single(s => s.LastName == "Alexander").ID,
            //        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
            //        Grade = Grade.A
            //    },
            //        new Enrollment {
            //        StudentID = students.Single(s => s.LastName == "Alexander").ID,
            //        CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
            //        Grade = Grade.C
            //        },
            //        new Enrollment {
            //        StudentID = students.Single(s => s.LastName == "Alexander").ID,
            //        CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
            //        Grade = Grade.B
            //        }
            //};

            //foreach (Enrollment e in enrollments)
            //{
            //    var enrollmentInDataBase = context.Enrollments.Where(
            //        s =>
            //                s.Student.ID == e.StudentID &&
            //                s.Course.CourseID == e.CourseID).SingleOrDefault();
            //    if (enrollmentInDataBase == null)
            //    {
            //        context.Enrollments.Add(e);
            //    }
            //}
            //context.SaveChanges();
        }


    }
}