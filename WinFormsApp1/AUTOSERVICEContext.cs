using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WinFormsApp1
{
    public partial class AUTOSERVICEContext : DbContext
    {
        public AUTOSERVICEContext()
        {
        }

        public AUTOSERVICEContext(DbContextOptions<AUTOSERVICEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Commition> Commitions { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Partlist> Partlists { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Systemtable> Systemtables { get; set; } = null!;
        public virtual DbSet<Work> Works { get; set; } = null!;
        public virtual DbSet<Worklist> Worklists { get; set; } = null!;
        public virtual DbSet<Worktype> Worktypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Port=55000;User Id=postgres;Password=714;Database=AUTOSERVICE;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("cars");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Carname)
                    .HasMaxLength(50)
                    .HasColumnName("carname");
            });

            modelBuilder.Entity<Commition>(entity =>
            {
                entity.ToTable("commitions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Workid).HasColumnName("workid");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Commitions)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("commitions_customerid_fkey");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Commitions)
                    .HasForeignKey(d => d.Employeeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("commitions_employeeid_fkey");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.Commitions)
                    .HasForeignKey(d => d.Workid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("commitions_workid_fkey");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Customername)
                    .HasMaxLength(50)
                    .HasColumnName("customername");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname");

                entity.Property(e => e.Passportn).HasColumnName("passportn");

                entity.Property(e => e.Passports).HasColumnName("passports");

                entity.Property(e => e.Posid).HasColumnName("posid");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Posid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_posid_fkey");
            });

            modelBuilder.Entity<Partlist>(entity =>
            {
                entity.ToTable("partlist");

                entity.HasIndex(e => e.Partlistid, "partlist_partlistid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Partlistid).HasColumnName("partlistid");

                entity.Property(e => e.Partname)
                    .HasMaxLength(50)
                    .HasColumnName("partname");

                entity.Property(e => e.Worktypeid).HasColumnName("worktypeid");

                entity.HasOne(d => d.Worktype)
                    .WithMany(p => p.Partlists)
                    .HasForeignKey(d => d.Worktypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("partlist_worktypeid_fkey");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("positions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Posname)
                    .HasMaxLength(50)
                    .HasColumnName("posname");
            });

            modelBuilder.Entity<Systemtable>(entity =>
            {
                entity.ToTable("systemtable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Command)
                    .HasMaxLength(50)
                    .HasColumnName("command");

                entity.Property(e => e.Commandname)
                    .HasMaxLength(50)
                    .HasColumnName("commandname");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.ToTable("work");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Carid).HasColumnName("carid");

                entity.Property(e => e.Partlistid).HasColumnName("partlistid");

                entity.Property(e => e.Worklistid).HasColumnName("worklistid");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.Carid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("work_carid_fkey");

                entity.HasOne(d => d.Partlist)
                    .WithMany(p => p.Works)
                    .HasPrincipalKey(p => p.Partlistid)
                    .HasForeignKey(d => d.Partlistid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("work_partlistid_fkey");

                entity.HasOne(d => d.Worklist)
                    .WithMany(p => p.Works)
                    .HasPrincipalKey(p => p.Worklistid)
                    .HasForeignKey(d => d.Worklistid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("work_worklistid_fkey");
            });

            modelBuilder.Entity<Worklist>(entity =>
            {
                entity.ToTable("worklist");

                entity.HasIndex(e => e.Worklistid, "worklist_worklistid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Worklistid).HasColumnName("worklistid");

                entity.Property(e => e.Workname)
                    .HasMaxLength(50)
                    .HasColumnName("workname");

                entity.Property(e => e.Worktypeid).HasColumnName("worktypeid");

                entity.HasOne(d => d.Worktype)
                    .WithMany(p => p.Worklists)
                    .HasForeignKey(d => d.Worktypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("worklist_worktypeid_fkey");
            });

            modelBuilder.Entity<Worktype>(entity =>
            {
                entity.ToTable("worktypes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Workname)
                    .HasMaxLength(50)
                    .HasColumnName("workname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
