﻿using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employee>().ToTable("employees");

        }
    }
}