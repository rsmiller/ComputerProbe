using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ComputerProbe.BusinessLayer.Models;
using ComputerProbe.BusinessLayer.Configurations;

namespace ComputerProbe.BusinessLayer
{
    public interface IProbeContext
    {
        DbSet<ProbeData> ProbeData { get; set; }
        DbSet<GPUData> GPUData { get; set; }
        DbSet<DriveData> DriveData { get; set; }
        DbSet<OSData> OSData { get; set; }
        DbSet<NetworkData> NetworkData { get; set; }
        DbSet<PrinterData> PrinterData { get; set; }
        DbSet<IPData> IPData { get; set; }
        DbSet<ProcessorData> ProcessorData { get; set; }
        DbSet<SoftwareData> SoftwareData { get; set; }
        DbSet<ErrorData> ErrorData { get; set; }
        DbSet<RAMData> RAMData { get; set; }
        int SaveChanges();
    }
    public class ProbeContext : DbContext, IProbeContext
    {
        private string _ConnectionString = "";
        public ProbeContext(string connectionString)
        {
            this._ConnectionString = connectionString;
        }

        public ProbeContext(DbContextOptions<ProbeContext> options, string connectionString)
            : base(options)
        {
            this._ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(this._ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProbeDataConfiguration());
            modelBuilder.ApplyConfiguration(new DriveDataConfiguration());
            modelBuilder.ApplyConfiguration(new GPUDataConfiguration());
            modelBuilder.ApplyConfiguration(new IPDataConfiguration());
            modelBuilder.ApplyConfiguration(new NetworkDataConfiguration());
            modelBuilder.ApplyConfiguration(new OSDataConfiguration());
            modelBuilder.ApplyConfiguration(new PrinterDataConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessorDataConfiguration());
            modelBuilder.ApplyConfiguration(new SoftwareDataConfiguration());
            modelBuilder.ApplyConfiguration(new ErrorDataConfiguration());
            modelBuilder.ApplyConfiguration(new RAMDataConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProbeData> ProbeData { get; set; }
        public DbSet<GPUData> GPUData { get; set; }
        public DbSet<DriveData> DriveData { get; set; }
        public DbSet<OSData> OSData { get; set; }
        public DbSet<NetworkData> NetworkData { get; set; }
        public DbSet<PrinterData> PrinterData { get; set; }
        public DbSet<IPData> IPData { get; set; }
        public DbSet<ProcessorData> ProcessorData { get; set; }
        public DbSet<SoftwareData> SoftwareData { get; set; }
        public DbSet<ErrorData> ErrorData { get; set; }
        public DbSet<RAMData> RAMData { get; set; }
    }
}
