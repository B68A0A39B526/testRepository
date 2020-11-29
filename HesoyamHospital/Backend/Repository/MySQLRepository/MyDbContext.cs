using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using Backend.Model.PharmacyModel;
using Backend.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Backend.Repository.MySQLRepository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<MedicalTherapy> Therapies { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<RegisteredPharmacy> RegisteredPharmacies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = Environment.GetEnvironmentVariable("MyDbConnectionString");
                optionsBuilder.UseLazyLoadingProxies().UseMySql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiseaseMedicine>().HasKey(dm => new { dm.DiseaseId, dm.MedicineId });
            modelBuilder.Entity<User>()
                    .ToTable("Users")
                    .HasDiscriminator<string>("ContentType")
                    .HasValue<User>("User")
                    .HasValue<Patient>("Patient")
                    .HasValue<SystemAdmin>("SystemAdmin")
                    .HasValue<Doctor>("Doctor")
                    .HasValue<Secretary>("Secretary")
                    .HasValue<Manager>("Manager");
        }
    }
}
