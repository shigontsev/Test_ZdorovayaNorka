using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ZdorovayaNorka.Common.Entities;

#nullable disable

namespace ZdorovayaNorka.DAL
{

    //Test_ZdorovayaNorka_DBContext
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlite("Data Source=E:\\\\\\\\Repos_Another\\\\\\\\Tests_REP\\\\\\\\Test_ZdorovayaNorka\\\\\\\\ZdorovayaNorka.WebApi\\\\\\\\App_Data\\\\\\\\Test_ZdorovayaNorka_DB.db");
                optionsBuilder.UseSqlite("Data Source=.\\\\\\\\App_Data\\\\\\\\Test_ZdorovayaNorka_DB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Employees_Id")
                    .IsUnique();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                //entity.Property(e => e.MiddleName).IsRequired();

                entity.Property(e => e.PositionId).HasColumnName("Position_Id");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Positions_Id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Positions_Name")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Shifts_Id")
                    .IsUnique();

                entity.Property(e => e.EmployeId).HasColumnName("Employe_Id");

                entity.Property(e => e.EndtShiftDate).HasColumnName("EndtShift_Date");

                entity.Property(e => e.StartShiftDate).HasColumnName("StartShift_Date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.EmployeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
