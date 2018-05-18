using System;
using Microsoft.EntityFrameworkCore; 

namespace WebApi.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(GetConnectionString());
        }

        private string GetConnectionString()
        {
            const string server = "localhost";
            const string databaseName = "ngnl_dev";
            const string userId = "sa";
            const string databasePassword = "masterkey";
            const string serverPort = "2000";

            return $"Server={server};" +
                    $"database={databaseName};" +
                    $"User Id={userId};" +
                    $"Password={databasePassword};" +
                    $"Port={serverPort};" +
                    $"Integrated Security=true;" +
                    $"pooling=true;";

        }

        public DbSet<Entities.employee> employees { get; set; }
        public DbSet<Entities.auth_user> auth_users { get; set; }
        public DbSet<Entities.auth_user_role> auth_user_roles { get; set; }
        public DbSet<Entities.Lookup> Lookups { get; set; }
        public DbSet<Entities.file_manager> file_manager { get; set; }
        public DbSet<Entities.employee_status> employee_status { get; set; }
        public DbSet<Entities.positions> positions { get; set; }
		public DbSet<Entities.banks> banks { get; set; }
		public DbSet<Entities.company> company { get; set; }
		public DbSet<Entities.company_addresses> company_addresses { get; set; }
		public DbSet<Entities.employee_addresses> employee_addresses { get; set; }
		public DbSet<Entities.municipality> municipality { get; set; }
		public DbSet<Entities.rdo> rdo { get; set; }
		public DbSet<Entities.alphanumeric_tax_codes> alphanumeric_tax_codes { get; set; }
		public DbSet<Entities.employee_dependents> employee_dependents { get; set; }
		public DbSet<Entities.employee_spouse> employee_spouse { get; set; }
		public DbSet<Entities.civil_status> civil_status { get; set; }
		public DbSet<Entities.employee_previous_employer> employee_previous_employer { get; set; }
		public DbSet<Entities.suffix> suffix { get; set; }
		public DbSet<Entities.citizenships> citizenships { get; set; }
		public DbSet<Entities.employee_identifications> employee_identifications { get; set; }
		public DbSet<Entities.employment_types> employment_types { get; set; }
		public DbSet<Entities.departments> departments { get; set; }
		public DbSet<Entities.cost_centers> cost_centers { get; set; }
		public DbSet<Entities.locations> locations { get; set; }
		public DbSet<Entities.tax_codes> tax_codes { get; set; }
		public DbSet<Entities.pay_groups> pay_groups { get; set; }
		public DbSet<Entities.payment_types> payment_types { get; set; }
		public DbSet<Entities.payroll_frequencies> payroll_frequencies { get; set; }
		public DbSet<Entities.identification_types> identification_types { get; set; }
		public DbSet<Entities.parameters> parameters { get; set; }
		public DbSet<Entities.time_sources> time_sources { get; set; }
		public DbSet<Entities.tax_computations> tax_computations { get; set; }
		public DbSet<Entities.tax_basis> tax_basis { get; set; }
		public DbSet<Entities._13th_month_types> _13th_month_types { get; set; }
		public DbSet<Entities._13th_month_round_directions> _13th_month_round_directions { get; set; }
		public DbSet<Entities.date_basis> date_basis { get; set; }
		public DbSet<Entities.payroll_periods> payroll_periods { get; set; }
		public DbSet<Entities.payroll_period_types> payroll_period_types { get; set; }
		public DbSet<Entities.pay_elements> pay_elements { get; set; }
		public DbSet<Entities.currencies> currencies { get; set; }
		public DbSet<Entities.day_types> day_types { get; set; }
		public DbSet<Entities.holiday_types> holiday_types { get; set; }
		public DbSet<Entities.hour_types> hour_types { get; set; }
		public DbSet<Entities.interest_rate_types> interest_rate_types { get; set; }
		public DbSet<Entities.interest_types> interest_types { get; set; }
		public DbSet<Entities.pay_tax_types> pay_tax_types { get; set; }
		public DbSet<Entities.time_types> time_types { get; set; }
		public DbSet<Entities.time_units> time_units { get; set; }
		public DbSet<Entities.payroll_hour_types> payroll_hour_types { get; set; }
		public DbSet<Entities.pay_element_types> pay_element_types { get; set; }
		public DbSet<Entities.de_minimis> de_minimis { get; set; }
		public DbSet<Entities.rates> rates { get; set; }
		public DbSet<Entities.pay_element_displays> pay_element_displays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employee>(entity => {
                    entity.ToTable("employees");
                    entity.Property(e => e.alphanumeric_tax_code_id).HasDefaultValueSql("0");
                    entity.Property(e => e.bank_id).HasDefaultValueSql("0");
                    entity.Property(e => e.citizenship_id).HasDefaultValueSql("0");
                    entity.Property(e => e.civil_status_id).HasDefaultValueSql("0");
                    entity.Property(e => e.company_id).HasDefaultValueSql("0");
                    entity.Property(e => e.cost_center_id).HasDefaultValueSql("0");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_of_birth).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.department_id).HasDefaultValueSql("0");
                    entity.Property(e => e.employee_spouse_id).HasDefaultValueSql("0");
                    entity.Property(e => e.employee_status_id).HasDefaultValueSql("0");
                    entity.Property(e => e.employment_type_id).HasDefaultValueSql("0");
                    entity.Property(e => e.gender_id).HasDefaultValueSql("0");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_union).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.location_id).HasDefaultValueSql("0");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.pay_group_id).HasDefaultValueSql("0");
                    entity.Property(e => e.payment_type_id).HasDefaultValueSql("0");
                    entity.Property(e => e.payroll_frequency_id).HasDefaultValueSql("0");
                    entity.Property(e => e.position_id).HasDefaultValueSql("0");
                    entity.Property(e => e.rdo_id).HasDefaultValueSql("0");
                    entity.Property(e => e.suffix_id).HasDefaultValueSql("0");
                    entity.Property(e => e.supervisor_id).HasDefaultValueSql("0");
                    entity.Property(e => e.telephone_number).HasDefaultValueSql("0");
                    entity.Property(e => e.work_type_id).HasDefaultValueSql("0");
                    entity.Property(e => e.parameter_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_effective).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.time_source_id).HasDefaultValueSql("1");
                }
            );

            modelBuilder.Entity<alphanumeric_tax_codes>(entity => {
                    entity.ToTable("alphanumeric_tax_codes");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_ewt).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_fb_tax).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_final_tax).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.rate).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<banks>(entity => {
                    entity.ToTable("banks");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<citizenships>(entity => {
                    entity.ToTable("citizenships");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<civil_status>(entity => {
                    entity.ToTable("civil_status");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<company>(entity => {
                    entity.ToTable("company");
                    entity.Property(e => e.bank_id).HasDefaultValueSql("0");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.rdo_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<company_addresses>(entity => {
                    entity.ToTable("company_addresses");
                    entity.Property(e => e.address_type_id).HasDefaultValueSql("0");
                    entity.Property(e => e.company_id).HasDefaultValueSql("0");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.municipality_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<cost_centers>(entity => {
                    entity.ToTable("cost_centers");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<departments>(entity => {
                    entity.ToTable("departments");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<employee_addresses>(entity => {
                    entity.ToTable("employee_addresses");
                    entity.Property(e => e.address_type_id).HasDefaultValueSql("0");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.employee_id).HasDefaultValueSql("0");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.municipality_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<employee_dependents>(entity => {
                    entity.ToTable("employee_dependents");
                    entity.Property(e => e.company_id).HasDefaultValueSql("0");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_of_birth).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.employee_id).HasDefaultValueSql("0");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_mentally_physically_incapacitated).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.relationship_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<employee_identifications>(entity => {
                    entity.ToTable("employee_identifications");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.effective_date).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.employee_id).HasDefaultValueSql("0");
                    entity.Property(e => e.expiry_date).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.identification_type_id).HasDefaultValueSql("0");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<employee_previous_employer>(entity => {
                    entity.ToTable("employee_previous_employer");
                    entity.Property(e => e._25_gross_taxable_compensation_income).HasDefaultValueSql("0");
                    entity.Property(e => e._27_premium_paid).HasDefaultValueSql("0");
                    entity.Property(e => e._31_total_tax_withheld).HasDefaultValueSql("0");
                    entity.Property(e => e._37_13th_month_pay_and_other_benefits).HasDefaultValueSql("0");
                    entity.Property(e => e._38_de_minimis_benefits).HasDefaultValueSql("0");
                    entity.Property(e => e._39_contributions_and_union_dues).HasDefaultValueSql("0");
                    entity.Property(e => e._40_salaries_and_compensation).HasDefaultValueSql("0");
                    entity.Property(e => e._51_taxable_13th_month_pay_and_other_benefits).HasDefaultValueSql("0");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.employee_id).HasDefaultValueSql("0");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.year).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<employee_spouse>(entity => {
                    entity.ToTable("employee_spouse");
                    entity.Property(e => e.company_id).HasDefaultValueSql("0");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_of_birth).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.employee_id).HasDefaultValueSql("0");
                    entity.Property(e => e.employment_status_id).HasDefaultValueSql("0");
                    entity.Property(e => e.is_claiming_exemptions).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<employee_status>(entity => {
                    entity.ToTable("employee_status");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<employment_types>(entity => {
                    entity.ToTable("employment_types");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_absorbed).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_contractual).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_outsourced).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_probation).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_process).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_project_based).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_regular).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_resigned).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_retired).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_temporary).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_terminated).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<identification_types>(entity => {
                    entity.ToTable("identification_types");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<locations>(entity => {
                    entity.ToTable("locations");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<municipality>(entity => {
                    entity.ToTable("municipality");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<pay_groups>(entity => {
                    entity.ToTable("pay_groups");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<payment_types>(entity => {
                    entity.ToTable("payment_types");
                    entity.Property(e => e.is_flat_rate).HasDefaultValueSql("TRUE");
                }
            );

            modelBuilder.Entity<payroll_frequencies>(entity => {
                    entity.ToTable("payroll_frequencies");
                    entity.Property(e => e.is_include_in_payroll_cut_off_generate).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_include_in_payroll_cut_off_schedule).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.order).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<positions>(entity => {
                    entity.ToTable("positions");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<rdo>(entity => {
                    entity.ToTable("rdo");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<suffix>(entity => {
                    entity.ToTable("suffix");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<tax_codes>(entity => {
                    entity.ToTable("tax_codes");
                    entity.Property(e => e.dependents).HasDefaultValueSql("0");
                    entity.Property(e => e.exemption).HasDefaultValueSql("0");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.sequence).HasDefaultValueSql("0");
                    entity.Property(e => e.year_end).HasDefaultValueSql("0");
                }
            );

            modelBuilder.Entity<parameters>(entity => {
                    entity.ToTable("parameters");
                    entity.Property(e => e._13th_month_round_direction_id).HasDefaultValueSql("1");
                    entity.Property(e => e._13th_month_round_factor).HasDefaultValueSql("0");
                    entity.Property(e => e._13th_month_type_id).HasDefaultValueSql("1");
                    entity.Property(e => e.company_id).HasDefaultValueSql("1");
                    entity.Property(e => e.created_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.cut_off_required_hours).HasDefaultValueSql("0");
                    entity.Property(e => e.date_created).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.date_modified).HasDefaultValueSql("NOW()");
                    entity.Property(e => e.days_in_week).HasDefaultValueSql("6");
                    entity.Property(e => e.days_in_year).HasDefaultValueSql("314");
                    entity.Property(e => e.fb_tax_rate).HasDefaultValueSql("0");
                    entity.Property(e => e.gross_up_per_payroll_to_pay_element_id).HasDefaultValueSql("0");
                    entity.Property(e => e.holiday_on_same_day_extra_pay_percent).HasDefaultValueSql("100");
                    entity.Property(e => e.hours_in_day).HasDefaultValueSql("8");
                    entity.Property(e => e.is_13th_month_ignore_absences).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_13th_month_ignore_midbreak).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_13th_month_ignore_tardy).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_13th_month_ignore_undertime).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_allow_rd_offset).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_allow_rh_offset).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_allow_sh_offset).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_allow_sh2_offset).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_compute_13th_month_projection).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_compute_gross_up_per_payroll).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_compute_hdmf_based_on_salary).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_compute_ndot).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_compute_non_regular_day_pay).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_compute_phic_based_on_salary).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_compute_salary_adjustment).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_compute_sss_based_on_salary).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_consider_not_yet_hired_resigned_on_paid_rh).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_consider_not_yet_hired_resigned_on_paid_sh).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_consider_not_yet_hired_resigned_on_paid_sh2).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_deduct_prev_13th_month_pay).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_exclude_no_time_summary).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_exclude_no_timesheet).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_holiday_on_same_day_with_extra_pay).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_hours_required_based_on_cut_off).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_ignore_absences).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_ignore_midbreak).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_ignore_tardy).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_ignore_undertime).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_lh_allow_paid_leave_day_before).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_lh_allow_unpaid_leave_day_before).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_lh_required_day_after).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_lh_required_day_before).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_lh_with_extra_pay).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_load_to_next_payroll).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_lr_with_extra_pay).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_major_deductions_based_on_salary).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_nd_premium_apply_to_all).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_ot_needs_approval).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_paid_lh).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_paid_sh).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_paid_sh2).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_reserve_non_taxable_to_projected_13th_month_pay).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_reserve_tax_free_bonus).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_s2r_with_extra_pay).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_sh_allow_paid_leave_day_before).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_sh_allow_unpaid_leave_day_before).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_sh_required_day_after).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_sh_required_day_before).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_sh_with_extra_pay).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_sh2_allow_paid_leave_day_before).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_sh2_allow_unpaid_leave_day_before).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_sh2_required_day_after).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_sh2_required_day_before).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_sh2_with_extra_pay).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_show_all_rates).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_sr_with_extra_pay).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.leave_accrual_date_basis_id).HasDefaultValueSql("1");
                    entity.Property(e => e.lh_extra_pay_percent).HasDefaultValueSql("100");
                    entity.Property(e => e.lr_extra_pay_percent).HasDefaultValueSql("100");
                    entity.Property(e => e.make_absent_equal_to_reg_basic_if_exceed_on_time_summary).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.make_absent_equal_to_reg_basic_if_exceed_on_timesheet).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.max_allowed_tardy_per_period).HasDefaultValueSql("0");
                    entity.Property(e => e.min_net_pay_for_loan).HasDefaultValueSql("0");
                    entity.Property(e => e.min_net_pay_for_loan_type_id).HasDefaultValueSql("2");
                    entity.Property(e => e.min_take_home_pay_basis_id).HasDefaultValueSql("1");
                    entity.Property(e => e.modified_by_id).HasDefaultValueSql("0");
                    entity.Property(e => e.nd_premium).HasDefaultValueSql("0.1");
                    entity.Property(e => e.new_hire_computation_basis_id).HasDefaultValueSql("1");
                    entity.Property(e => e.normalize_tax_refund_pay_month).HasDefaultValueSql("0");
                    entity.Property(e => e.normalize_tax_refund_payroll_period_id).HasDefaultValueSql("0");
                    entity.Property(e => e.ot_excess_rate_required_hours_after_shift).HasDefaultValueSql("0");
                    entity.Property(e => e.payment_type_id).HasDefaultValueSql("1");
                    entity.Property(e => e.s2r_extra_pay_percent).HasDefaultValueSql("100");
                    entity.Property(e => e.sh_extra_pay_percent).HasDefaultValueSql("100");
                    entity.Property(e => e.sh2_extra_pay_percent).HasDefaultValueSql("100");
                    entity.Property(e => e.sr_extra_pay_percent).HasDefaultValueSql("100");
                    entity.Property(e => e.tax_basis_id).HasDefaultValueSql("1");
                    entity.Property(e => e.tax_computation_id).HasDefaultValueSql("1");
                    entity.Property(e => e.tax_free_bonus).HasDefaultValueSql("0");
                    entity.Property(e => e.taxable_fringe_benefit_pay_element_id).HasDefaultValueSql("0");
                    entity.Property(e => e.taxable_income_pay_element_id).HasDefaultValueSql("0");
                    entity.Property(e => e.union_dues).HasDefaultValueSql("0");
                    entity.Property(e => e.weeks_in_year).HasDefaultValueSql("52");
                }
            );

            modelBuilder.Entity<time_sources>(entity => {
                    entity.ToTable("time_sources");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.is_create_timesheet).HasDefaultValueSql("FALSE");
                }
            );

            modelBuilder.Entity<tax_basis>(entity => {
                    entity.ToTable("tax_basis");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                }
            );

            modelBuilder.Entity<date_basis>(entity => {
                    entity.ToTable("date_basis");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                }
            );

            modelBuilder.Entity<payroll_periods>(entity => {
                    entity.ToTable("payroll_periods");
                    entity.Property(e => e.is_active).HasDefaultValueSql("TRUE");
                    entity.Property(e => e.period_order).HasDefaultValueSql("0");
                    entity.Property(e => e.company_id).HasDefaultValueSql("1");
                    entity.Property(e => e.payroll_period_type_id).HasDefaultValueSql("0");
                    entity.Property(e => e.is_regular_payroll_period).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_13th_month_pay).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_final_pay).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_annualization).HasDefaultValueSql("FALSE");
                    entity.Property(e => e.is_special_payroll).HasDefaultValueSql("FALSE");
                }
            );
        }
    }
}