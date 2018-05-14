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