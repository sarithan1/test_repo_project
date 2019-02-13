using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EmployeeCoreWebAPI.Models
{
    public partial class EmployeeDBContext : DbContext
    {
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                 optionsBuilder.UseSqlServer(@"Server=NARASIMHA-PC\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;");
               // var builder = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile("appsetttings.json");
               // var configuration = DbContextOptionsBuilder.
                //optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            }
        }


        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options) { }

        public EmployeeDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("tblEmployee");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmployeeCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName).HasMaxLength(50);
            });
        }
    }
}
