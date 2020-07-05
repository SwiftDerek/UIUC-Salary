using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace UIUCSalary.Models
{
    public partial class UIUCSalaryContext : DbContext
    {
        private readonly IConfiguration _config;

        public UIUCSalaryContext(IConfiguration config)
        {
            _config = config;
        }

        public UIUCSalaryContext(DbContextOptions<UIUCSalaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("UIUCSalaryDB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Job__Employee_ID__2D27B809");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Job__Position_ID__2E1BDC42");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Job__Unit_ID__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
